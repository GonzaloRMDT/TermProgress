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
        private readonly IPublishingService publishingService;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger{T}"/> implementation with a generic type argument of <see cref="TermProgressController"/>.</param>
        /// <param name="publishingService">A <see cref="IPublishingService"/> implementation.</param>
        public TermProgressController(ILogger<TermProgressController> logger, IPublishingService publishingService)
        {
            this.logger = logger;
            this.publishingService = publishingService;
        }

        /// <summary>
        /// Publishes term progress on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <returns>A <see cref="Task{TResult}"/> instance with a generic type argument of <see cref="IMessage"/>.</returns>
        [HttpPost("{network}")]
        public async Task<IMessage> PublishAsync(string network)
        {
            logger.LogInformation("User requested term status creation.");
            return await publishingService.PublishAsync(network);
        }
    }
}
