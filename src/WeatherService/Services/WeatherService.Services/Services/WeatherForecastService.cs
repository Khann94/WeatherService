#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WeatherService.Database.Entity;
using WeatherService.Database.Repository.Interface;
using WeatherService.Services.Models;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Services.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        #region Private field(s)

        private readonly Lazy<IIntegrationService> IntergrationServiceProvider;
        private readonly Lazy<ICityRepository> CityRepositoryProvider;
        private readonly Lazy<IMapper> MapperProvider;

        #endregion

        #region Constructor(s)

        public WeatherForecastService(
            Lazy<IIntegrationService> intergrationServiceProvider,
            Lazy<ICityRepository> cityRepositoryProvider,
            Lazy<IMapper> mapperProvider,
            ILogger<WeatherForecastService> logger)
        {
            IntergrationServiceProvider = intergrationServiceProvider;
            CityRepositoryProvider = cityRepositoryProvider;
            MapperProvider = mapperProvider;
            Logger = logger;
        }

        #endregion

        #region Private properties

        private IIntegrationService IntergrationService => IntergrationServiceProvider.Value;

        private ICityRepository CityRepository => CityRepositoryProvider.Value;
        
        private IMapper Mapper => MapperProvider.Value;

        private ILogger<WeatherForecastService> Logger;

        #endregion

        #region Public method(s)

        public async Task UpdateWeatherForExistingCities()
        {
            Logger.LogInformation($"Starting updating weather for cities from database");
            var cities = await CityRepository.GetAllCitiesWithWeathers();

            foreach (var city in cities)
            {
                Logger.LogInformation($"Making call by coordinates lat {city.Latitude}, long {city.Longitude}, city {city.Name}, cityExternalId {city.ExternalId}");
                var weatherFromApi = await IntergrationService.GetWeatherForCoordinates(city.Latitude, city.Longitude);

                Logger.LogInformation($"Updating weather for city {city.Name}, cityExternalId {city.ExternalId}");
                // We only want to store the newest weather data
                city.Weathers.Clear();
                city.Weathers.AddRange(Mapper.Map<List<Weather>>(weatherFromApi));

                Logger.LogInformation($"Weather updated for city {city.Name}, cityExternalId {city.ExternalId}");
            }

            await CityRepository.Update(cities);
            Logger.LogInformation($"Weather for cities has been updated");
            return;
        }

        public async Task<CityServiceModel> GetCityByExternalId(Guid externalId)
        {
            var city = await CityRepository.GetByExternalIdOrNull(externalId)
                ?? throw new Exception("Incorrect externalId to get city");

            var mapped = Mapper.Map<CityServiceModel>(city);

            return mapped;
        }

        public async Task<List<WeatherServiceModel>> GetWeatherForCoordinates(double latitude, double longitude)
        {
            var weathers = await IntergrationService.GetWeatherForCoordinates(latitude, longitude);

            return weathers;
        }

        #endregion
    }
}
