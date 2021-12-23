using TermProgress.Library.Authentications;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Defines the common structure for authentication services.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="userCredentials">A <see cref="UserCredentials"/> instance.</param>
        /// <returns>JSON Web Token string.</returns>
        string Authenticate(UserCredentials userCredentials);
    }
}