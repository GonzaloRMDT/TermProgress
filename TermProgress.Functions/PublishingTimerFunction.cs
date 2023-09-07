using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TermProgress.Functions.Clients;
using TermProgress.Functions.Options;

namespace TermProgress.Functions
{
    /// <summary>
    /// Represents a message publishing timer function.
    /// </summary>
    public class PublishingTimerFunction
    {
        private readonly ITermProgressApiClient termProgressApiClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="termProgressApiClient">A <see cref="ITermProgressApiClient"/> implementation.</param>
        ///
        public PublishingTimerFunction(ITermProgressApiClient termProgressApiClient)
        {
            this.termProgressApiClient = termProgressApiClient;
        }

        /// <summary>
        /// Runs function asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="myTimer">A <see cref="TimerInfo"/> instance..</param>
        /// <param name="logger">A <see cref="ILogger"/> implementation.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        [FunctionName("PublishingTimerFunction")]
        public async Task Run([TimerTrigger("%PublishingTimerFunctionSchedule%")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"Requesting creation of new Twitter status at {DateTime.Now}.");
            await termProgressApiClient.RequestMessageCreationAsync();
        }
    }
}
