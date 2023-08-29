using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TermProgress.Infrastructure.Apis.Commons.Exchanges;
using TermProgress.Library.Authentications.ApiKey.Attributes;
using TermProgress.Library.Services;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents a term progress controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiKeyAuthentication]
    public class TermProgressController : ControllerBase
    {
        private readonly ILogger<TermProgressController> logger;
        private readonly ITermProgressService termProgressService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TermProgressController"/> class.
        /// </summary>
        /// <param name="logger">A <see cref="ILogger{T}"/> with a generic type argument of <see cref="TermProgressController"/>.</param>
        /// <param name="termProgressService">A <see cref="ITermProgressService"/> implementation.</param>
        public TermProgressController(ILogger<TermProgressController> logger, ITermProgressService termProgressService)
        {
            this.logger = logger;
            this.termProgressService = termProgressService;
        }

        /// <summary>
        /// Creates term progress message on given social network asynchronously.
        /// </summary>
        /// <param name="network">Name of social network to publish on.</param>
        /// <returns>A <see cref="Task{T}"/> with a generic type argument of <see cref="CreateMessageResponse?"/>.</returns>
        [HttpPost("{network}")]
        public async Task<CreateMessageResponse?> CreateAsync(string network)
        {
            logger.LogInformation("User requested term status creation.");

            return await termProgressService.CreateAsync(network);
        }
    }
}
