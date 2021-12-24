using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TermProgress.Library.Authentications.JsonWebTokens.Extensions;
using TermProgress.Library.Clients;
using TermProgress.Library.Options;
using TermProgress.Library.Services;
using TermProgress.Library.Terms;
using TermProgress.WebAPI.Exceptions;
using TermProgress.WebAPI.HttpErrors;

namespace TermProgress.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddAutoMapper(typeof(Program).Assembly, typeof(TwitterClientOptions).Assembly)
                .AddExceptionHandling()
                .AddHttpErrorHandling()
                .AddJsonWebToken(Configuration.GetSection(nameof(TokenOptions)))
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IPublishingService, PublishingService>()
                .AddScoped<IClient<IMessage>, TwitterClient>()
                .AddScoped<ITerm, Term>()
                .Configure<ApplicationOptions>(Configuration.GetSection(nameof(ApplicationOptions)))
                .Configure<TermOptions>(Configuration.GetSection(nameof(TermOptions)))
                .Configure<TwitterClientOptions>(Configuration.GetSection(nameof(TwitterClientOptions)))
                .Configure<RequestLocalizationOptions>(options =>
                {
                    var culture = Configuration
                        .GetSection(nameof(ApplicationOptions))
                        .Get<ApplicationOptions>()
                        .Culture;

                    options.DefaultRequestCulture = new RequestCulture(culture);
                });

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment())
            {
                app.UseExceptionHandling("/api/v1/exceptions/local-development-exception");
            }
            else if (env.IsStaging() || env.IsProduction())
            {
                app.UseExceptionHandling("/api/v1/exceptions/exception");
            }

            app.UseRequestLocalization();

            app.UseHttpErrorHandling("/api/v1/http-errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
