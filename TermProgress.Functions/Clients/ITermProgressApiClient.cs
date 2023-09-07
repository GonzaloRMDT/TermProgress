using System;
using System.Threading.Tasks;

namespace TermProgress.Functions.Clients
{
    /// <summary>
    /// Defines the common structure for Term Progress API clients.
    /// </summary>
    public interface ITermProgressApiClient : IDisposable
    {
        /// <summary>
        /// Requests message creation asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task RequestMessageCreationAsync();
    }
}