using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        /// GET: api/v1/status
        ///
        /// <summary>
        /// Gets the API status.
        /// </summary>
        /// <returns>API status.</returns>
        [HttpGet]
        public string Get()
        {
            return "Ok";
        }
    }
}
