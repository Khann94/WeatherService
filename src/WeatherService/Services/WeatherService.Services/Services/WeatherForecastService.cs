#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WeatherService.Database.Repository.Interface;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Services.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        #region Private field(s)

        private readonly Lazy<IIntergrationService> IntergrationServiceProvider;
        private readonly Lazy<IWeatherRepository> WeatherRepositoryProvider;
        private readonly Lazy<IMapper> MapperProvider;

        #endregion

        #region Constructor(s)

        public WeatherForecastService(
            Lazy<IIntergrationService> intergrationServiceProvider,
            Lazy<IWeatherRepository> weatherRepositoryProvider,
            Lazy<IMapper> mapperProvider)
        {
            IntergrationServiceProvider = intergrationServiceProvider;
            WeatherRepositoryProvider = weatherRepositoryProvider;
            MapperProvider = mapperProvider;
        }

        #endregion

        #region Private properties

        private IIntergrationService IntergrationService => IntergrationServiceProvider.Value;

        private IWeatherRepository WeatherRepository => WeatherRepositoryProvider.Value;
        
        private IMapper Mapper => MapperProvider.Value;

        #endregion

        #region Public method(s)

        #endregion
    }
}
