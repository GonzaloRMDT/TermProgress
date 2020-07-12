using TermProgress.Library.Authentications;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// <c>IAuthenticationService</c> interface.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <returns>JSON Web Token string.</returns>
        string Authenticate(UserCredentials userCredentials);
    }
}