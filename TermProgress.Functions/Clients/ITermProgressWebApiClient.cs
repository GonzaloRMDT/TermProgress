using System.Threading.Tasks;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Defines the common structure for term progress web API clients.
    /// </summary>
    public interface ITermProgressWebApiClient
    {
        /// <summary>
        /// Requests message publishing asynchronously.
        /// </summary>
        /// <param name="apiKey">Application authentication API key.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task RequestPublishingAsync(string apiKey);
    }
}