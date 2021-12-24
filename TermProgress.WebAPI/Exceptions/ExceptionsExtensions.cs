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
        /// <param name="services">A <see cref="IServiceCollection"/> implementation.</param>
        /// <returns>A <see cref="IServiceCollection"/> implementation.</returns>
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
        /// <param name="app">An <see cref="IApplicationBuilder"/> implementation.</param>
        /// <param name="exceptionHandlingPath">Exception handling path.</param>
        /// <returns>An <see cref="IApplicationBuilder"/> implementation.</returns>
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, string exceptionHandlingPath)
        {
            return app.UseExceptionHandler(exceptionHandlingPath);
        }
    }
}
