using System.Threading.Tasks;
using TermProgress.Library.Clients;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// <c>IStatusCreationService</c> interface.
    /// </summary>
    public interface IStatusCreationService
    {
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="clientType">Client type.</param>
        /// <returns>Task with social network status</returns>
        Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType);
    }
}