#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
            Lazy<IMapper> mapperProvider)
        {
            IntergrationServiceProvider = intergrationServiceProvider;
            CityRepositoryProvider = cityRepositoryProvider;
            MapperProvider = mapperProvider;
        }

        #endregion

        #region Private properties

        private IIntegrationService IntergrationService => IntergrationServiceProvider.Value;

        private ICityRepository CityRepository => CityRepositoryProvider.Value;
        
        private IMapper Mapper => MapperProvider.Value;

        #endregion

        #region Public method(s)

        public async Task UpdateWeatherForExistingCities()
        {
            var cities = await CityRepository.GetAllCitiesWithWeathers();

            foreach (var city in cities)
            {
                // TODO Logic to update weather
            }

            await CityRepository.Update(cities);

            return;
        }

        public async Task<CityServiceModel> GetByExternalId(Guid externalId)
        {
            var city = await CityRepository.GetByExternalIdOrNull(externalId)
                ?? throw new Exception("Incorrect externalId to get city");

            var mapped = Mapper.Map<CityServiceModel>(city);

            return mapped;
        }

        public async Task GetWeatherForCoordinates(double latitude, double longitude)
        {
            await IntergrationService.GetWeatherForCoordinates(latitude, longitude);
        }

        #endregion
    }
}
