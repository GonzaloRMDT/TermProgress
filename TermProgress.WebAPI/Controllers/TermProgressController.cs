using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Library.Authentications.ApiKey.Attributes;
using TermProgress.Library.Services;
using TermProgress.Library.Services.Models;
using TermProgress.Library.Services.Models.Enums;
using TermProgress.WebAPI.Dtos.Requests;
using TermProgress.WebAPI.Dtos.Responses;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents a term progress controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiKeyAuthentication]
    public class TermProgressController : ControllerBase
    {
        private readonly ILogger<TermProgressController> logger;
        private readonly ITermProgressService termProgressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressController"/> class.
        /// </summary>
        /// <param name="logger">A logger implementation.</param>
        /// <param name="termProgressService">A term progress service implementation.</param>
        public TermProgressController(ILogger<TermProgressController> logger, ITermProgressService termProgressService)
        {
            this.logger = logger;
            this.termProgressService = termProgressService;
        }

        /// <summary>
        /// Creates a term progress status on given social network asynchronously.
        /// </summary>
        /// <param name="network">The name of the social network where the status shall be created.</param>
        /// <param name="request">The status creation request.</param>
        /// <returns>
        /// An action result implementation with an
        /// HTTP status code 201 (Created) and the status object as the response body
        /// when the requested status creation has been completed succesfully, or an
        /// HTTP status code 202 (Accepted) when the requested status creation has been scheduled for later retry.
        /// </returns>
        [HttpPost("{network}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TermProgressStatusCreationResponse))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> CreateStatusAsync(
            string network,
            [FromBody] TermProgressStatusCreationRequest request)
        {
            logger.LogInformation("User requested term status creation with "
                + $"start date {request.StartDate.Date} and end date {request.EndDate.Date}.");

            Response<Status> response = await termProgressService.CreateStatusAsync(
                network,
                request.StartDate,
                request.EndDate);

            if (response.Result == RequestResult.Scheduled)
            {
                return Accepted();
            }

            return StatusCode(
                StatusCodes.Status201Created,
                new TermProgressStatusCreationResponse
                {
                    Id = response.Data!.Id,
                    Text = response.Data!.Text
                });
        }
    }
}
