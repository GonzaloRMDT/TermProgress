using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TermProgress.Library.Clients;
using TermProgress.Library.Configurations;
using TermProgress.Library.Terms;
using Microsoft.AspNetCore.Localization;
using TermProgress.Library.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TermProgress.Library.Authentications.JsonWebTokens;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TermProgress.Library.Authentications.JsonWebTokens.Extensions;

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
                .AddAutoMapper(typeof(Program).Assembly, typeof(TwitterClientConfiguration).Assembly)
                .AddJsonWebToken(Configuration.GetSection(nameof(JsonWebTokenConfiguration)))
                .AddSingleton<IClient, TwitterClient>()
                .AddSingleton<ISystemClock, SystemClock>()
                .AddSingleton<ITerm, Term>()
                .AddSingleton<ITermMessage, TermMessage>()
                .AddSingleton<ITermProgressBar, TermProgressBar>()
                .AddSingleton<ITermProgressBarBlockFactory, TermProgressBarBlockFactory>()
                .Configure<ApplicationConfiguration>(Configuration.GetSection(nameof(ApplicationConfiguration)))
                .Configure<TermConfiguration>(Configuration.GetSection(nameof(TermConfiguration)))
                .Configure<TwitterClientConfiguration>(Configuration.GetSection(nameof(TwitterClientConfiguration)))
                .Configure<RequestLocalizationOptions>(options =>
                {
                    var culture = Configuration
                        .GetSection(nameof(ApplicationConfiguration))
                        .Get<ApplicationConfiguration>()
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

            app.UseRequestLocalization();

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
