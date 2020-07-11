using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using TermProgress.Worker.Clients;

namespace TermProgress.Worker
{
    public class TermProgressWorker
    {
        /// <summary>
        /// Term progress web API client instance.
        /// </summary>
        private ITermProgressWebApiClient _termProgressWebApiClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termProgressWebApiClient">Term progress web API client instance.</param>
        public TermProgressWorker(ITermProgressWebApiClient termProgressWebApiClient)
        {
            _termProgressWebApiClient = termProgressWebApiClient;
        }

        /// <summary>
        /// Runs worker asynchronously.
        /// </summary>
        /// <param name="myTimer">Timer instance.</param>
        /// <param name="logger">Logger instance.</param>
        /// <remarks>Asynchronous method.</remarks>
        [FunctionName("TermProgressWorker")]
        public async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger logger)
        {
            // Create status
            logger.LogInformation("Requesting creation of new Twitter status.");
            var tokenResponse = await _termProgressWebApiClient.RequestUserAuthenticationTokenAsync();
            await _termProgressWebApiClient.RequestTwitterStatusCreationAsync(tokenResponse.Token);
        }
    }
}