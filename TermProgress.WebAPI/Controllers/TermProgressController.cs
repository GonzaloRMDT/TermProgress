using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TermProgress.Application.Publishers;
using TermProgress.Application.Publishers.Dtos.Enums;
using TermProgress.Application.Publishers.Dtos.Requests;
using TermProgress.Application.Publishers.Dtos.Responses;
using TermProgress.Domain.Authentications.ApiKey.Attributes;
using TermProgress.WebAPI.Exchanges.Requests;
using TermProgress.WebAPI.Exchanges.Responses;

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
        private readonly IMapper mapper;
        private readonly IPublishingService publishingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressController"/> class.
        /// </summary>
        /// <param name="logger">A logger implementation.</param>
        /// <param name="publishingService">A publishing service implementation.</param>
        public TermProgressController(
            ILogger<TermProgressController> logger,
            IMapper mapper,
            IPublishingService publishingService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.publishingService = publishingService;
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
        /// HTTP status code 202 (Accepted) when the requested status creation has been scheduled for later retry, or an
        /// HTTP status code 502 (Bad Gateway) when request to social network API produces an error.
        /// </returns>
        [HttpPost("{network}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateStatusResponse))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> CreateStatusAsync(string network, [FromBody] CreateStatusRequest request)
        {
            logger.LogInformation(
                "User requested term status creation with start date {StartDate} and end date {EndDate}.",
                request.StartDate!.Value.Date.ToString("s"),
                request.EndDate!.Value.Date.ToString("s"));

            CreateStatusRequestDto requestDto = mapper.Map<CreateStatusRequestDto>(request);
            CreateStatusResponseDto responseDto = await publishingService.CreateStatusAsync(requestDto);

            if (responseDto.Result is RequestResult.Scheduled)
            {
                return Accepted();
            }
            else if (responseDto.Result is RequestResult.Error)
            {
                return StatusCode(StatusCodes.Status502BadGateway);
            }

            return StatusCode(StatusCodes.Status201Created, mapper.Map<CreateStatusResponse>(responseDto.Data));
        }
    }
}
