using TermProgress.Infrastructure.Apis.Commons.Exchanges;

namespace TermProgress.Infrastructure.Apis.Commons.Interfaces
{
    /// <summary>
    /// Defines the common structure for API clients.
    /// </summary>
    public interface IApiClient : IDisposable
    {
        /// <summary>
        /// Creates a message asynchronously.
        /// </summary>
        /// <param name="text">The message text.</param>
        /// <returns>The message creation response.</returns>
        Task<CreateMessageResponse?> CreateMessageAsync(string text);
    }
}
