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
        /// <summary>
        /// Handles exceptions in non-development environments.
        /// </summary>
        /// <param name="webHostEnvironment">A <see cref="IHostingEnvironment"/> implementation.</param>
        /// <returns>A <see cref="IActionResult"/> implementation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when called in development environment.</exception>
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

        /// <summary>
        /// Handles exception in local development environments.
        /// </summary>
        /// <param name="webHostEnvironment">A <see cref="IHostingEnvironment"/> implementation.</param>
        /// <returns>An <see cref="IActionResult"/> implementation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when called in non development environments.</exception>
        [Route("local-development-exception")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult ExceptionLocalDevelopment([FromServices] IHostingEnvironment webHostEnvironment)
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
