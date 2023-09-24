using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TermProgress.Application.Publishers;
using TermProgress.Application.Publishers.Dtos;
using TermProgress.Application.Publishers.Dtos.Enums;
using TermProgress.Domain.Authentications.ApiKey.Attributes;
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
        private readonly ITermProgressPublishingService termProgressPublishingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressController"/> class.
        /// </summary>
        /// <param name="logger">A logger implementation.</param>
        /// <param name="termProgressPublishingService">A term progress publishing service implementation.</param>
        public TermProgressController(ILogger<TermProgressController> logger, ITermProgressPublishingService termProgressPublishingService)
        {
            this.logger = logger;
            this.termProgressPublishingService = termProgressPublishingService;
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
                + $"start date {request.StartDate!.Value.Date} and end date {request.EndDate!.Value.Date}.");

            ResponseDto<StatusDto> response = await termProgressPublishingService.CreateStatusAsync(
                network,
                request.StartDate!.Value,
                request.EndDate!.Value);

            if (response.Result is RequestResult.Scheduled)
            {
                return Accepted();
            }
            else if (response.Result is RequestResult.Error)
            {
                return StatusCode(StatusCodes.Status502BadGateway);
            }

            return StatusCode(StatusCodes.Status201Created, response.Data);
        }
    }
}
