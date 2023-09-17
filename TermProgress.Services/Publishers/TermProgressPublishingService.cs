using Polly;
using RestSharp;
using System.Net;
using TermProgress.Application.Publishers.Models;
using TermProgress.Application.Publishers.Models.Enums;
using TermProgress.Domain.Terms;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;

namespace TermProgress.Application.Publishers
{
    /// <summary>
    /// Represents a term progress publishing service.
    /// </summary>
    public class TermProgressPublishingService : ITermProgressPublishingService
    {
        private readonly IEnumerable<IApiClient> apiClients;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressPublishingService"/> class.
        /// </summary>
        /// <param name="apiClients">The API clients.</param>
        /// <param name="termMessage">A term message implementation.</param>
        public TermProgressPublishingService(IEnumerable<IApiClient> apiClients, ITermMessage termMessage)
        {
            this.apiClients = apiClients;
            this.termMessage = termMessage;
        }

        public async Task<Response<Status>> CreateStatusAsync(string network, DateTime startDate, DateTime endDate)
        {
            IApiClient apiClient = apiClients
                .Single(apiClient => apiClient.GetType().Name
                .Contains(network, StringComparison.OrdinalIgnoreCase));

            // Term progress message
            termMessage.Term.SetStartDate(startDate);
            termMessage.Term.SetEndDate(endDate);
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

            return new Response<Status>
            {
                Result = response.Result.IsSuccessful ? RequestResult.Success : RequestResult.Error,
                Data = response.Result.Data
            };
        }
    }
}
