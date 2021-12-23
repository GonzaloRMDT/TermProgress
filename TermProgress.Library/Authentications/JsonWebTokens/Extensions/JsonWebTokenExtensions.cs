using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TermProgress.Library.Options;

namespace TermProgress.Library.Authentications.JsonWebTokens.Extensions
{
    /// <summary>
    /// Represents the JSON Web Token extensions.
    /// </summary>
    public static class JsonWebTokenExtensions
    {
        /// <summary>
        /// Adds Json Web Token options and services.
        /// </summary>
        /// <param name="services">A <see cref="IServiceCollection"/> implementation.</param>
        /// <param name="configuration">A <see cref="IConfiguration"/> implementation.</param>
        /// <returns>A <see cref="IServiceCollection"/> implementation.</returns>
        public static IServiceCollection AddJsonWebToken(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOptions>(configuration);
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
