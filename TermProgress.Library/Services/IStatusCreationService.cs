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
        Task CreateStatus(ClientType clientType);
    }
}