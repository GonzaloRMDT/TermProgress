using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Authentications.JsonWebTokens.Extensions
{
    /// <summary>
    /// Represents the JSON Web Token extensions.
    /// </summary>
    public static class JsonWebTokenExtensions
    {
        /// <summary>
        /// Adds Json Web Token configuration and services.
        /// </summary>
        /// <param name="services"><c>IServiceCollection</c> instance.</param>
        /// <param name="config"><c>IConfiguration</c> instance.</param>
        /// <returns><c>IServiceCollection</c> instance.</returns>
        public static IServiceCollection AddJsonWebToken(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JsonWebTokenConfiguration>(config);
            services.AddScoped<IJsonWebTokenBuilder, JsonWebTokenBuilder>();
            services.AddScoped<IJsonWebTokenHeaderBuilder, JsonWebTokenHeaderBuilder>();
            services.AddScoped<IJsonWebTokenPayloadBuilder, JsonWebTokenPayloadBuilder>();
            services.AddScoped<IJsonWebTokenSerialBuilder, JsonWebTokenSerialBuilder>();
            services.AddSingleton<ITokenValidationParametersFactory, TokenValidationParametersFactory>();

            services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
                .Configure<ITokenValidationParametersFactory>((opts, tokenValidationParametersFactory) =>
                {
                    opts.TokenValidationParameters = tokenValidationParametersFactory.Create();
                });
            return services;
        }

    }
}
