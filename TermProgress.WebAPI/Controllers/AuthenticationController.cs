using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TermProgress.Library.Authentications;
using TermProgress.Library.Services;

namespace TermProgress.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<AuthenticationController> _logger;

        /// <summary>
        /// Authentication service instance.
        /// </summary>
        private readonly IAuthenticationService _authenticationService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="authenticationService">Authentication service instance.</param>
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
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
            _logger.LogInformation("User requested authentication.");

            string authentication = _authenticationService.Authenticate(userCredentials);

            if (string.IsNullOrWhiteSpace(authentication) == true)
            {
                return Unauthorized();
            }

            return Ok(new TokenResponse { Token = authentication });
        }
    }
}