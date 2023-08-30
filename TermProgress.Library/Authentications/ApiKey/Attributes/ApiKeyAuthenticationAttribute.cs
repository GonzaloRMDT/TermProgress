using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace TermProgress.Library.Authentications.ApiKey.Attributes
{
    /// <summary>
    /// Represents an API key authentication attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthenticationAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyHeaderValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            IConfiguration configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            string? apiKey = configuration.GetValue<string>(ApiKeyHeaderName);

            if (apiKey is not null && !apiKey.Equals(apiKeyHeaderValue))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}