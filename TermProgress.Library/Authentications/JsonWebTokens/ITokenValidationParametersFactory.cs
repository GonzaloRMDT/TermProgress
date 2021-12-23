using Microsoft.IdentityModel.Tokens;

namespace TermProgress.Library.Authentications.JsonWebTokens
{
    /// <summary>
    /// Defines the common structure for token validation parameters factories.
    /// </summary>
    public interface ITokenValidationParametersFactory
    {
        /// <summary>
        /// Creates the token validation parameters.
        /// </summary>
        /// <returns>A <see cref="TokenValidationParameters"/> instance.</returns>
        TokenValidationParameters Create();
    }
}