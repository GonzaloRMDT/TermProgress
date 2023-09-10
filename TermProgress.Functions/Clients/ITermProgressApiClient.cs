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
        /// Requests status creation asynchronously.
        /// </summary>
        /// <param name="startDate">The term start date.</param>
        /// <param name="endDate">The term end date.</param>
        /// <returns>A <see cref="Task"/> instance.</returns>
        Task RequestStatusCreationAsync(DateTime startDate, DateTime endDate);
    }
}