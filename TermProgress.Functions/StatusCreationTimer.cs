using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TermProgress.Functions.Clients;
using TermProgress.Functions.Options;

namespace TermProgress.Functions
{
    /// <summary>
    /// Represents a term progress status creation timer.
    /// </summary>
    public class StatusCreationTimer
    {
        private readonly FunctionOptions functionOptions;
        private readonly ITermProgressApiClient termProgressApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCreationTimer"/> class.
        /// </summary>
        /// <param name="functionOptions">The function options.</param>
        /// <param name="termProgressApiClient">A <see cref="ITermProgressApiClient"/> implementation.</param>
        public StatusCreationTimer(
            IOptions<FunctionOptions> functionOptions,
            ITermProgressApiClient termProgressApiClient)
        {
            this.functionOptions = functionOptions.Value;
            this.termProgressApiClient = termProgressApiClient;
        }

        /// <summary>
        /// Runs function asynchronously.
        /// </summary>
        /// <param name="myTimer">The timer information.</param>
        /// <param name="logger">A <see cref="ILogger"/> implementation.</param>
        [FunctionName("StatusCreationTimer")]
        public async Task Run([TimerTrigger("%StatusCreationTimerSchedule%")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation("Requesting creation of new Twitter status.");

            HttpStatusCode[] httpStatusCodesWorthRetrying = {
               HttpStatusCode.RequestTimeout, // 408
               HttpStatusCode.InternalServerError, // 500
               HttpStatusCode.BadGateway, // 502
               HttpStatusCode.ServiceUnavailable, // 503
               HttpStatusCode.GatewayTimeout // 504
            };

            await Policy<RestResponse>
                .HandleResult(r => httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .ExecuteAndCaptureAsync(async () => await termProgressApiClient.RequestStatusCreationAsync(
                    functionOptions.StartDate!.Value,
                    functionOptions.EndDate!.Value));
        }
    }
}
