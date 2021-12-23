using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents an exceptions controllers.
    /// </summary>
    [Route("api/{version}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionsController : ControllerBase
    {
        [Route("exception")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Exception([FromServices] IHostingEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException("Cannot invoke non-development error action method on development environment.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var problemDetails = new ProblemDetails
            {
                Detail = null,
                Instance = feature?.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Internal server error."
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }

        [Route("local-development-exception")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ExcepctionLocalDevelopment([FromServices] IHostingEnvironment webHostEnvironment)
        {
            if (!webHostEnvironment.IsDevelopment())
            {
                throw new InvalidOperationException("Cannot invoke local development exception action method on non-development environment.");
            }

            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;

            var problemDetails = new ProblemDetails
            {
                Detail = ex.StackTrace,
                Instance = feature?.Path,
                Status = (int)HttpStatusCode.InternalServerError,
                Title = $"{ex.GetType().Name}: {ex.Message}"
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
