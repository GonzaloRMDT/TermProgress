using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TermProgress.Library.Clients;
using TermProgress.Library.Services;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents a term progress controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TermProgressController : ControllerBase
    {
        /// <summary>
        /// Logger instance.
        /// </summary>
        private readonly ILogger<TermProgressController> _logger;

        /// <summary>
        /// Status creation service.
        /// </summary>
        private readonly IStatusCreationService _statusCreationService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">Logger instance.</param>
        /// <param name="statusCreationService">Status creation service.</param>
        public TermProgressController(ILogger<TermProgressController> logger, IStatusCreationService statusCreationService)
        {
            _logger = logger;
            _statusCreationService = statusCreationService;
        }

        /// POST api/v1/TermProgress/{client}/[action]
        /// 
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <param name="clientType">Client type.</param>
        [HttpPost("{client}/[action]")]
        public async Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType)
        {
            _logger.LogInformation("User requested term status creation on Twitter.");
            return await _statusCreationService.CreateStatusAsync(clientType);
        }
    }
}
