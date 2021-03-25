#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherService.Services.HostedService.Interface;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Services.HostedService
{
    public class WeatherHostedService : IWeatherHostedService
    {
        #region Private

        private int FifeMinutes => 5 * 60 * 1000;
        private readonly ILogger<WeatherHostedService> Logger;
        private IWeatherForecastService WeatherService;

        #endregion

        #region Constructor

        public WeatherHostedService(
            ILogger<WeatherHostedService> logger,
            IWeatherForecastService weatherService)
        {
            Logger = logger;
            WeatherService = weatherService;
        }

        #endregion

        #region Public method(s)

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("Updating weather for cities.");

                await WeatherService.UpdateWeatherForExistingCities();

                Logger.LogInformation("Weather Hosted Service is working. Weather updated.");
                await Task.Delay(FifeMinutes, stoppingToken);
            }
        }

        #endregion
    }
}
