using System.Threading.Tasks;
using TermProgress.Library.Clients;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Defines the common structure of status creation services.
    /// </summary>
    public interface IStatusCreationService
    {
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="clientType">A <see cref="ClientType"/> value.</param>
        /// <returns>A <see cref="Task{T}"/> with a generic type argument of <see cref="SocialNetworkStatus"/>.</returns>
        Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType);
    }
}