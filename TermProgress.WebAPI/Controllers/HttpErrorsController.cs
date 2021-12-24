using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace TermProgress.WebAPI.Controllers
{
    /// <summary>
    /// Represents an HTTP errors controllers.
    /// </summary>
    [Route("api/{version}/[controller]")]
    [Route("api/{version}/errors")]
    [Route("api/{version}/http-errors")]
    [Route("api/[controller]")]
    [Route("api/errors")]
    [Route("api/http-errors")]
    [ApiController]
    public class HttpErrorsController : ControllerBase
    {
        [Route("{statusCode}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error(int statusCode)
        {
            IStatusCodeReExecuteFeature statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            string originalUrl = null;

            if (statusCodeReExecuteFeature != null)
            {
                originalUrl =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            ProblemDetails problemDetails = new ProblemDetails
            {
                Instance = originalUrl,
                Status = statusCode,
                Title = ReasonPhrases.GetReasonPhrase(statusCode)
            };

            return StatusCode(problemDetails.Status.Value, problemDetails);
        }
    }
}
