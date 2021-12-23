using System.Threading.Tasks;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// Defines the common structure for clients.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <param name="message">Status message.</param>
        /// <returns>A <see cref="Task{T}"/> with a generic type argument of <see cref="SocialNetworkStatus"/>.</returns>
        Task<SocialNetworkStatus> CreateStatusAsync(string message);
    }
}
