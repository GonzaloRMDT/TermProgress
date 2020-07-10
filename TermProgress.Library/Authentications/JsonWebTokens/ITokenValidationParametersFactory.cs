using Microsoft.IdentityModel.Tokens;

namespace TermProgress.Library.Authentications.JsonWebTokens
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