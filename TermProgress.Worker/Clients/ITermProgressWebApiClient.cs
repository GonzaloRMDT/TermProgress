using System.Threading.Tasks;
using TermProgress.Library.Authentications;

namespace TermProgress.Worker.Clients
{
    /// <summary>
    /// <c>ITermProgressWebApiClient</c> interface.
    /// </summary>
    public interface ITermProgressWebApiClient
    {
        /// <summary>
        /// Requests user authentication token asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <returns>Task object with <c>TokenResponse</c> instance.</returns>
        Task<TokenResponse> RequestUserAuthenticationTokenAsync();

        /// <summary>
        /// Requests Twitter status creation asynchronously.
        /// </summary>
        /// <remarks>Asynchronous method.</remarks>
        /// <param name="token">Authentication token.</param>
        /// <returns>Empty <c>Task</c> object.</returns>
        Task RequestTwitterStatusCreationAsync(string token);
    }
}