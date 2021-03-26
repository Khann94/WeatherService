#region Usings

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using WeatherService.Common.Consts;
using WeatherService.Services.Models;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Services.Services
{
    public class IntegrationService : IIntegrationService
    {
        #region Constructor(s)

        public IntegrationService(ILogger<IntegrationService> logger)
        {
            Logger = logger;
        }

        #endregion

        #region Private properties

        private readonly ILogger<IntegrationService> Logger;

        #endregion

        #region Public method(s)

        public async Task<List<WeatherServiceModel>> GetWeatherForCoordinates(double latitude, double longitude)
        {
            var  weatherInWrapper = new WeatherIntegrationServiceModel();
            ValidateCoordinates(latitude, longitude);
            try
            {
                Logger.LogInformation($"Making call to 7timer.infor for lat {latitude} and long {longitude}");

                weatherInWrapper = await new FlurlClient(Config.TimeInfoUrl)
                    .Request()
                    .SetQueryParam("lon", longitude)
                    .SetQueryParam("lat", latitude)
                    .SetQueryParam("meteo", 0)
                    .SetQueryParam("unit", "metric")
                    .SetQueryParam("output", "json")
                    .SetQueryParam("tzshift", 0)
                    .GetJsonAsync<WeatherIntegrationServiceModel>();

                Logger.LogInformation($"Receive data from 7timer.infor for lat {latitude} and long {longitude}");
            }
            catch (Exception e)
            {
                Logger.LogError($"Error while making call to 7timer.info for lat {latitude} and long {longitude}, {e}");
                throw e;
            }

            return weatherInWrapper.DataSeries;
        }

        #endregion

        #region Private methods

        private void ValidateCoordinates(double latitude, double longitude)
        {
            if (latitude < -90 || latitude > 90)
            {
                throw new Exception("Latitude need to be between -90 to 90");
            }

            if (longitude < -180 || longitude > 180)
            {
                throw new Exception("Latitude need to be between -90 to 90");
            }
        }

        #endregion
    }
}
