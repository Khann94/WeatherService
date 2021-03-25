#region Usings

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using WeatherService.Services.Initializer;

#endregion

namespace WeatherService
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration().CreateLogger();

                Log.Information("Starting web host.");

                var host = CreateHostBuilder(args)
                    .Build();

                await InitializeDatabaseAsync(host);

                await host.RunAsync();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");

                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new DefaultServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task InitializeDatabaseAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            try
            {
                var initializer = serviceProvider.GetRequiredService<Initializer>();

                await initializer.InitializeAsync();
            }
            catch (Exception exception)
            {
                var errorLogger = serviceProvider.GetRequiredService<ILogger<Program>>();

                errorLogger.LogError(exception, "An error occurred while seeding the database.");

                throw new Exception("An error occurred while seeding the database.", exception);
            }
        }
    }
}
