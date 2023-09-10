using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        /// <param name="functionOptions">
        /// A <see cref="IOptions{TOptions}"/> implementation with a
        /// generic type parameter of <see cref="FunctionOptions"/>.
        /// </param>
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
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="myTimer">A <see cref="TimerInfo"/> instance..</param>
        /// <param name="logger">A <see cref="ILogger"/> implementation.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        [FunctionName("StatusCreationTimer")]
        public async Task Run([TimerTrigger("%StatusCreationTimerSchedule%")] TimerInfo myTimer, ILogger logger)
        {
            logger.LogInformation("Requesting creation of new Twitter status.");
            await termProgressApiClient.RequestStatusCreationAsync(
                functionOptions.StartDate!.Value,
                functionOptions.EndDate!.Value);
        }
    }
}
