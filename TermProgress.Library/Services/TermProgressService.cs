using Polly;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;
using TermProgress.Infrastructure.Apis.Commons.Entities;
using TermProgress.Library.Services.Models;
using TermProgress.Library.Services.Models.Enums;
using TermProgress.Library.Terms;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Represents a term progress service.
    /// </summary>
    public class TermProgressService : ITermProgressService
    {
        private readonly IEnumerable<IApiClient> apiClients;
        private readonly ITermMessage termMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressService"/> class.
        /// </summary>
        /// <param name="apiClients">
        /// An <see cref="IEnumerable{T}"/> with a generic type argument of <see cref="IApiClient"/>.
        /// </param>
        /// <param name="termMessage">A <see cref="ITermMessage"/> implementation.</param>
        public TermProgressService(IEnumerable<IApiClient> apiClients, ITermMessage termMessage)
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
