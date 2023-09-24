using RestSharp;
using TermProgress.Infrastructure.Apis.Commons.Entities;

namespace TermProgress.Infrastructure.Apis.Commons.Interfaces
{
    /// <summary>
    /// Defines the common structure for API clients.
    /// </summary>
    public interface IApiClient : IDisposable
    {
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <returns>The status creation response.</returns>
        Task<RestResponse<Status>> CreateStatusAsync(string text);
    }
}
