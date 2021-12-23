using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
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
        private readonly ILogger<TermProgressController> logger;
        private readonly IStatusCreationService statusCreationService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger{T}"/> implementation with a generic type argument of <see cref="TermProgressController"/>.</param>
        /// <param name="statusCreationService">A <see cref="IStatusCreationService"/> implementation.</param>
        public TermProgressController(ILogger<TermProgressController> logger, IStatusCreationService statusCreationService)
        {
            this.logger = logger;
            this.statusCreationService = statusCreationService;
        }

        /// POST api/v1/TermProgress/{client}/[action]
        /// <summary>
        /// Creates status asynchronously.
        /// </summary>
        /// <param name="clientType">A <see cref="ClientType"/> value.</param>
        /// <returns>A <see cref="Task{T}"/> with a generic type argument of <see cref="SocialNetworkStatus"/>.</returns>
        [HttpPost("{client}/[action]")]
        public async Task<SocialNetworkStatus> CreateStatusAsync(ClientType clientType)
        {
            logger.LogInformation("User requested term status creation on Twitter.");
            return await statusCreationService.CreateStatusAsync(clientType);
        }
    }
}
