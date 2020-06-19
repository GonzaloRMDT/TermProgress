using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TermProgress.Library.Clients;
using TermProgress.Library.Terms;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents a term progress controller.
    /// </summary>
    [Route("api/v1/[controller]")]
    public class TermProgressController : ControllerBase
    {
        /// <summary>
        /// Client instance.
        /// </summary>
        private readonly IClient _client;

        /// <summary>
        /// Term message.
        /// </summary>
        private readonly ITermMessage _termMessage;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="client">Client instance.</param>
        /// <param name="termMessage">Term message instance.</param>
        public TermProgressController(IClient client, ITermMessage termMessage)
        {
            _client = client;
            _termMessage = termMessage;
        }

        /// POST api/v1/TermProgress/{client}/[action]
        /// 
        /// <summary>
        /// Creates status.
        /// </summary>
        [HttpPost("{client}/[action]")]
        public async void CreateStatus()
        {
            string termMessage = _termMessage.Compose();
            await _client.CreateStatusAsync(termMessage);
        }
    }
}
