using System;
using System.Threading.Tasks;

namespace TermProgress.Library.Clients
{
    /// <summary>
    /// <c>IClient</c> interface.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="message">Status message.</param>
        /// <returns>Task with social network status.</returns>
        Task<SocialNetworkStatus> CreateStatusAsync(string message);
    }
}
