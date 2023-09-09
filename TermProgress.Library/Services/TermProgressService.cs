using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Exchanges;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;
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

        public async Task<StatusCreationResponse?> CreateStatusAsync(string network, DateTime startDate, DateTime endDate)
        {
            IApiClient apiClient = apiClients
                .Single(apiClient => apiClient.GetType().Name
                .Contains(network, StringComparison.OrdinalIgnoreCase));

            // Term progress message
            termMessage.Term.StartingDate = startDate;
            termMessage.Term.EndingDate = endDate;
            string message = termMessage.ToString()!;

            // Status creation
            var retryPolicy = Policy
                .HandleResult<StatusCreationResponse?>(result => result is null)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy
                .HandleResult<StatusCreationResponse?>(result => result is null)
                .CircuitBreakerAsync(5, TimeSpan.FromMinutes(1));

            PolicyResult<StatusCreationResponse?> response = await Policy
                .WrapAsync(retryPolicy, circuitBreakerPolicy)
                .ExecuteAndCaptureAsync(async () => await apiClient.CreateStatusAsync(message));

            return response.Result;
        }
    }
}
