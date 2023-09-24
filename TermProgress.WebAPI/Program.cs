using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;

namespace TermProgress.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Early initialization of logger to allow startup and exception logging, before host is built
            Logger logger = LogManager
                .Setup()
                .LoadConfigurationFromAppSettings()
                .GetCurrentClassLogger();

            logger.Debug("Initializing main program...");

            try
            {
                string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                    ?? throw new InvalidOperationException("Environment name could not be retrieved.");

                logger = LogManager
                   .Setup()
                   .LoadConfigurationFromAppSettings(basePath: AppContext.BaseDirectory, $"nlog.{environment}.config")
                   .GetCurrentClassLogger();

                IHostBuilder builder = Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    })
                    .UseNLog();

                IHost app = builder.Build();

                app.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
