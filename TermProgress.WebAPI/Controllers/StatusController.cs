using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<StatusController> _logger;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        /// GET: api/v1/status
        ///
        /// <summary>
        /// Gets the API status.
        /// </summary>
        /// <returns>API status.</returns>
        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("User requested status.");
            return "Ok";
        }
    }
}
