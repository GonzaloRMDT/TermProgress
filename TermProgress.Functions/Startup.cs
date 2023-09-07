using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TermProgress.Functions.Clients;
using TermProgress.Functions.Options;

[assembly: FunctionsStartup(typeof(TermProgress.Functions.Startup))]
namespace TermProgress.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<ApplicationOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection(nameof(ApplicationOptions)).Bind(settings);
                });

            builder.Services
                .AddHttpClient()
                .AddSingleton<ITermProgressApiClient, TermProgressApiClient>();
        }
    }
}
