using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TermProgress.Library.Authentications;
using TermProgress.Library.Authentications.JsonWebTokens;
using TermProgress.Library.Options;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Represents an authentication service.
    /// </summary>
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IOptions<ApplicationOptions> applicationOptions;
        private readonly IOptions<TokenOptions> tokenOptions;
        private readonly IJsonWebTokenBuilder tokenBuilder;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationOptions">A <see cref="IOptions{T}"/> with a generic type argument of <see cref="ApplicationOptions"/>.</param>
        /// <param name="tokenOptions">A <see cref="IOptions{T}"/> with a generic type argument of <see cref="TokenOptions"/>.</param>
        /// <param name="tokenBuilder">A <see cref="IJsonWebTokenBuilder"/> implementation.</param>
        public AuthenticationService(
            IOptions<ApplicationOptions> applicationOptions,
            IOptions<TokenOptions> tokenOptions,
            IJsonWebTokenBuilder tokenBuilder)
        {
            this.applicationOptions = applicationOptions;
            this.tokenOptions = tokenOptions;
            this.tokenBuilder = tokenBuilder;
        }

        public string Authenticate(UserCredentials userCredentials)
        {
            if (IsAuthenticatedUser(userCredentials))
            {
                string jsonWebToken = tokenBuilder
                    .SetEncoding(Encoding.UTF8)
                    .SetSecretKey(tokenOptions.Value.SecretKey)
                    .SetAlgorithm(SecurityAlgorithms.HmacSha256)
                    .SetIssuer(tokenOptions.Value.Issuer)
                    .SetAudience(tokenOptions.Value.Audience)
                    .SetValidSince(DateTime.Now)
                    .SetExpiration(DateTime.Now.Add(tokenOptions.Value.TokenLifetime))
                    .AddClaim(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()))
                    .AddClaim(new Claim("name", userCredentials.Username))
                    .AddClaim(new Claim(ClaimTypes.Role, "Admin"))
                    .Build();

                return jsonWebToken;
            }

            return null;
        }

        public bool IsAuthenticatedUser(UserCredentials userCredentials)
        {
            bool isValidUsername = applicationOptions.Value.AdminUsername == userCredentials.Username;
            bool isValidPassword = applicationOptions.Value.AdminPassword == userCredentials.Password;
            bool isAuthenticUser = isValidUsername && isValidPassword;
            return isAuthenticUser;
        }
    }
}
