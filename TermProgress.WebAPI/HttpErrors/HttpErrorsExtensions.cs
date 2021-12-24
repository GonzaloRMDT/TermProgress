﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TermProgress.WebAPI.Controllers;

namespace TermProgress.WebAPI.HttpErrors
{
    /// <summary>
    /// Represents the HTTP errors extensions.
    /// </summary>
    public static class HttpErrorsExtensions
    {
        /// <summary>
        /// Adds HTTP error handling services.
        /// </summary>
        /// <param name="services">A service collection instance.</param>
        /// <returns>A service collection instance.</returns>
        public static IServiceCollection AddHttpErrorHandling(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddApplicationPart(Assembly.GetAssembly(typeof(HttpErrorsController)));

            return services;
        }

        /// <summary>
        /// Adds HTTP error handling middleware.
        /// </summary>
        /// <remarks>
        /// Handles HTTP errors by reexecuting the pipeline to given error handling path when request
        /// produces a 400 to 599 status code.
        /// </remarks>
        /// <param name="app">Application builder instance.</param>
        /// <param name="httpErrorHandlingPath">HTTP error handling path.</param>
        /// <returns>Application builder instance.</returns>
        public static IApplicationBuilder UseHttpErrorHandling(this IApplicationBuilder app, string httpErrorHandlingPath)
        {
            return app.UseStatusCodePagesWithReExecute(httpErrorHandlingPath);
        }
    }
}
