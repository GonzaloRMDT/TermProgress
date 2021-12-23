using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TermProgress.WebAPI.Controllers;

namespace TermProgress.WebAPI.Exceptions
{
    /// <summary>
    /// Represents the exceptions extensions.
    /// </summary>
    public static class ExceptionsExtensions
    {
        /// <summary>
        /// Adds exception handling services.
        /// </summary>
        /// <param name="services">A service collection instance.</param>
        /// <returns>A service collection instance.</returns>
	    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddApplicationPart(Assembly.GetAssembly(typeof(ExceptionsController)));

            return services;
        }

        /// <summary>
        /// Adds exception handling middleware.
        /// </summary>
        /// <remarks>
        /// Handles exceptions by reexecuting the pipeline
        /// to given exception handling path when request produces an unhandled exception.
        /// </remarks>
        /// <param name="app">Application builder instance.</param>
        /// <param name="exceptionHandlingPath">Exception handling path.</param>
        /// <returns>Application builder instance.</returns>
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, string exceptionHandlingPath)
        {
            return app.UseExceptionHandler(exceptionHandlingPath);
        }
    }
}
