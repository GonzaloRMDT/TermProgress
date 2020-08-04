using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TermProgress.Library.Configurations;

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
        /// <summary>
        /// Application configuration.
        /// </summary>
        private readonly ApplicationConfiguration _applicationConfiguration;

        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<StatusController> _logger;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        public StatusController(IOptions<ApplicationConfiguration> applicationConfiguration, ILogger<StatusController> logger)
        {
            _applicationConfiguration = applicationConfiguration.Value;
            _logger = logger;
        }

        /// GET: api/v1/status
        ///
        /// <summary>
        /// Gets the API status.
        /// </summary>
        /// <returns>API status.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("User requested status.");

            var apiStatus = new
            {
                Status = "online",
                Version = _applicationConfiguration.Version
            };

            return Ok(apiStatus);
        }
    }
}
