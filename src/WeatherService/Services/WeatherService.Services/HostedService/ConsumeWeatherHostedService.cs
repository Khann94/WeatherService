#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherService.Services.HostedService.Interface;

#endregion

namespace WeatherService.Services.HostedService
{
    public class ConsumeWeatherHostedService : BackgroundService
    {
        #region Private

        private readonly ILogger<ConsumeWeatherHostedService> Logger;
        private IServiceProvider Services { get; }

        #endregion

        #region Constructor

        public ConsumeWeatherHostedService(IServiceProvider services,
            ILogger<ConsumeWeatherHostedService> logger)
        {
            Services = services;
            Logger = logger;
        }

        #endregion

        #region Public

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }

        #endregion

        #region Protected

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation(
                "Consume Scoped Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        #endregion

        #region Private

        private async Task DoWork(CancellationToken stoppingToken)
        {
            Logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IWeatherHostedService>()
                    ?? throw new ArgumentNullException("Missing Weather Hosted Service in backgroud job");

                await scopedProcessingService.DoWork(stoppingToken);
            }
        }

        #endregion
    }
}
