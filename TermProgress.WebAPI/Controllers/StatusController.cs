using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents the status controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> logger;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger{T}"/> implementation with a generic type argument of <see cref="StatusController"/>.</param>
        public StatusController(ILogger<StatusController> logger)
        {
            this.logger = logger;
        }

        /// GET: api/v1/status
        /// <summary>
        /// Gets the API status.
        /// </summary>
        /// <returns>API status.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("User requested status.");

            var apiStatus = new
            {
                Status = "online", // TODO: add from common library
                //Version = applicationOptions.Version
            };

            return Ok(apiStatus);
        }
    }
}
