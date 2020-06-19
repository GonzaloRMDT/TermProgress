using System;
using System.Threading.Tasks;
using Tweetinvi.Models;

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
        Task<ITweet> CreateStatusAsync(string message);
    }
}
