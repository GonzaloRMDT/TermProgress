using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TermProgress.Library.Authentications;
using TermProgress.Library.Authentications.JsonWebTokens;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Services
{
    /// <summary>
    /// Authentication service.
    /// </summary>
    /// <inheritdoc />
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Application configuration.
        /// </summary>
        private readonly ApplicationConfiguration _applicationConfiguration;

        /// <summary>
        /// JSON Web Token configuration.
        /// </summary>
        private readonly JsonWebTokenConfiguration _jsonWebTokenConfiguration;

        /// <summary>
        /// JSON Web Token builder.
        /// </summary>
        private readonly IJsonWebTokenBuilder _jsonWebTokenBuilder;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="applicationConfiguration">Application configuration.</param>
        /// <param name="jsonWebTokenConfiguration">JSON Web Token configuration.</param>
        /// <param name="jsonWebTokenBuilder">JSON Web Token builder</param>
        public AuthenticationService(
            IOptions<ApplicationConfiguration> applicationConfiguration,
            IOptions<JsonWebTokenConfiguration> jsonWebTokenConfiguration,
            IJsonWebTokenBuilder jsonWebTokenBuilder)
        {
            _applicationConfiguration = applicationConfiguration.Value;
            _jsonWebTokenConfiguration = jsonWebTokenConfiguration.Value;
            _jsonWebTokenBuilder = jsonWebTokenBuilder;
        }

        public string Authenticate(UserCredentials userCredentials)
        {
            if (IsAuthenticatedUser(userCredentials))
            {
                string jsonWebToken = _jsonWebTokenBuilder
                    .SetEncoding(Encoding.UTF8)
                    .SetSecretKey(_jsonWebTokenConfiguration.SecretKey)
                    .SetAlgorithm(SecurityAlgorithms.HmacSha256)
                    .SetIssuer(_jsonWebTokenConfiguration.Issuer)
                    .SetAudience(_jsonWebTokenConfiguration.Audience)
                    .SetValidSince(DateTime.Now)
                    .SetExpiration(DateTime.Now.Add(_jsonWebTokenConfiguration.TokenLifetime))
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
            bool isValidUsername = _applicationConfiguration.AdminUsername == userCredentials.Username;
            bool isValidPassword = _applicationConfiguration.AdminPassword == userCredentials.Password;
            bool isAuthenticUser = isValidUsername && isValidPassword;
            return isAuthenticUser;
        }
    }
}
