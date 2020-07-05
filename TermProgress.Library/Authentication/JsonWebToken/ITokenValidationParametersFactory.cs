using Microsoft.IdentityModel.Tokens;

namespace TermProgress.Library.Authentication.JsonWebToken
{
    /// <summary>
    /// <c>ITokenValidationParametersFactory</c> interface.
    /// </summary>
    public interface ITokenValidationParametersFactory
    {
        /// <summary>
        /// Creates <c>TokenValidationParameters</c> instance.
        /// </summary>
        /// <returns><c>TokenValidationParameters</c> instance.</returns>
        TokenValidationParameters Create();
    }
}