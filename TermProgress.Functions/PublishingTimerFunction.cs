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
        private readonly IOptions<ApplicationOptions> applicationOptions;
        private readonly ITermProgressWebApiClient termProgressWebApiClient;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationOptions">A <see cref="IOptions{TOptions}"/> implementation with a generic type paramenter of <see cref="ApplicationOptions"/>.</param>
        /// <param name="termProgressWebApiClient">A <see cref="ITermProgressWebApiClient"/> implementation.</param>
        public PublishingTimerFunction(IOptions<ApplicationOptions> applicationOptions, ITermProgressWebApiClient termProgressWebApiClient)
        {
            this.applicationOptions = applicationOptions;
            this.termProgressWebApiClient = termProgressWebApiClient;
        }

        /// <summary>
        /// Runs function asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="myTimer">A <see cref="TimerInfo"/> instance..</param>
        /// <param name="logger">A <see cref="ILogger"/> implementation.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        [FunctionName("PublishingTimerFunction")]
        public async Task Run([TimerTrigger("0 0 0 * * *")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation($"Requesting creation of new Twitter status at {DateTime.Now}.");
            await termProgressWebApiClient.RequestPublishingAsync(applicationOptions.Value.ApiKey);
        }
    }
}
