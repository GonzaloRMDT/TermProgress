using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TermProgress.Worker.Clients;
using TermProgress.Worker.Configurations;

[assembly: FunctionsStartup(typeof(TermProgress.Worker.Startup))]
namespace TermProgress.Worker
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<ApplicationConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(ApplicationConfiguration)).Bind(settings);
                });

            builder.Services
                .AddHttpClient()
                .AddSingleton<ITermProgressWebApiClient, TermProgressWebApiClient>();
        }
    }
}