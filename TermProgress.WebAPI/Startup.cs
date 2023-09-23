using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TermProgress.Application.Publishers;
using TermProgress.Domain.Options;
using TermProgress.Domain.Terms;
using TermProgress.Infrastructure.Apis.Commons.Interfaces;
using TermProgress.Infrastructure.Apis.Twitter;
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
                .AddAutoMapper(typeof(Program).Assembly, typeof(TermProgressPublishingService).Assembly)
                .AddExceptionHandling()
                .AddHttpErrorHandling()
                .AddScoped<ITermProgressPublishingService, TermProgressPublishingService>()
                .AddScoped<ITerm, Term>()
                .AddScoped<ITermMessage, TermMessage>()
                .AddSingleton<IApiClient>(
                    new TwitterApiClient(
                        Configuration["TwitterClientOptions:ConsumerKey"]!,
                        Configuration["TwitterClientOptions:ConsumerKeySecret"]!,
                        Configuration["TwitterClientOptions:AccessToken"]!,
                        Configuration["TwitterClientOptions:AccessTokenSecret"]!
                    )
                )
                .Configure<ApplicationOptions>(Configuration.GetSection(nameof(ApplicationOptions)))
                .Configure<RequestLocalizationOptions>(options =>
                {
                    string? culture = Configuration
                        .GetSection(nameof(ApplicationOptions))
                        .Get<ApplicationOptions>()?
                        .Culture;

                    options.DefaultRequestCulture = new RequestCulture(culture ?? "es-AR");
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
