using AutoMapper;
using Polly;
using RestSharp;
using System.Net;
using TermProgress.Application.Publishers.Dtos.Requests;
using TermProgress.Application.Publishers.Dtos.Responses;
using TermProgress.Domain.Terms;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;

namespace TermProgress.Application.Publishers
{
    // TODO: Simplify class name.

    /// <summary>
    /// Represents a term progress publishing service.
    /// </summary>
    public class TermProgressPublishingService : ITermProgressPublishingService
    {
        private readonly IEnumerable<IApiClient> apiClients;
        private readonly IMapper mapper;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressPublishingService"/> class.
        /// </summary>
        /// <param name="apiClients">The API clients.</param>
        /// <param name="mapper">A mapper implementation.</param>
        /// <param name="termMessage">A term message implementation.</param>
        public TermProgressPublishingService(
            IEnumerable<IApiClient> apiClients,
            IMapper mapper,
            ITermMessage termMessage)
        {
            this.apiClients = apiClients;
            this.mapper = mapper;
            this.termMessage = termMessage;
        }

        public async Task<CreateStatusResponseDto> CreateStatusAsync(CreateStatusRequestDto request)
        {
            IApiClient apiClient = apiClients
                .Single(apiClient => apiClient.GetType().Name
                .Contains("twitter", StringComparison.OrdinalIgnoreCase)); // TODO: Get network property
                                                                           //.Contains(network, StringComparison.OrdinalIgnoreCase));

            // Term progress message
            termMessage.Term.SetStartDate(request.StartDate);
            termMessage.Term.SetEndDate(request.EndDate);
            string message = termMessage.GetMessage();

            // Status creation
            HttpStatusCode[] httpStatusCodesWorthRetrying = {
               HttpStatusCode.RequestTimeout,  // 408
               HttpStatusCode.InternalServerError,  // 500
               HttpStatusCode.BadGateway,  // 502
               HttpStatusCode.ServiceUnavailable,  // 503
               HttpStatusCode.GatewayTimeout  // 504
            };

            var retryPolicy = Policy<RestResponse<Status>>
                .HandleResult(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy<RestResponse<Status>>
                .HandleResult(r => !r.IsSuccessful)
                .CircuitBreakerAsync(5, TimeSpan.FromMinutes(1));

            PolicyResult<RestResponse<Status>> response = await Policy
                .WrapAsync(retryPolicy, circuitBreakerPolicy) // TODO: Check if order should be inverted
                .ExecuteAndCaptureAsync(async () => await apiClient.CreateStatusAsync(message));

            return mapper.Map<CreateStatusResponseDto>(response.Result);
        }
    }
}
