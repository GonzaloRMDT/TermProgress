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
        private readonly ILogger<AuthenticationController> logger;
        private readonly IAuthenticationService authenticationService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger{T}"/> implementation with a generic type argument of <see cref="AuthenticationController"/>.</param>
        /// <param name="authenticationService">A <see cref="IAuthenticationService"/> implementation.</param>
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            this.logger = logger;
            this.authenticationService = authenticationService;
        }

        /// POST api/v1/authentication
        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="userCredentials">A <see cref="UserCredentials"/> instance.</param>
        /// <returns>JSON Web Token for authenticated user; else, unauthorized response.</returns>
        [HttpPost]
        public IActionResult Authenticate(UserCredentials userCredentials)
        {
            logger.LogInformation("User requested authentication.");

            string authentication = authenticationService.Authenticate(userCredentials);

            if (string.IsNullOrWhiteSpace(authentication) == true)
            {
                return Unauthorized();
            }

            return Ok(new TokenResponse { Token = authentication });
        }
    }
}