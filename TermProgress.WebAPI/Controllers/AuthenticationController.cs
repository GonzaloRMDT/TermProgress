using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TermProgress.Library.Authentications;
using TermProgress.Library.Authentications.JsonWebTokens;
using TermProgress.Library.Configurations;

namespace TermProgress.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
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
        public AuthenticationController(
            IOptions<ApplicationConfiguration> applicationConfiguration,
            IOptions<JsonWebTokenConfiguration> jsonWebTokenConfiguration,
            IJsonWebTokenBuilder jsonWebTokenBuilder)
        {
            _applicationConfiguration = applicationConfiguration.Value;
            _jsonWebTokenConfiguration = jsonWebTokenConfiguration.Value;
            _jsonWebTokenBuilder = jsonWebTokenBuilder;
        }

        /// POST api/v1/authentication
        /// 
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="userCredentials">User credentials.</param>
        /// <returns>JSON Web Token for authenticated user; else, unauthorized response.</returns>
        [HttpPost]
        public IActionResult Authenticate(UserCredentials userCredentials)
        {
            if (_applicationConfiguration.AdminUsername == userCredentials.Username
                && _applicationConfiguration.AdminPassword == userCredentials.Password)
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

                return Ok(new { Token = jsonWebToken });
            }

            return Unauthorized();
        }
    }
}