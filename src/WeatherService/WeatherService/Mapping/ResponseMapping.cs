#region Usings

using AutoMapper;
using WeatherService.Api.Models.Response;
using WeatherService.Services.Models;

#endregion

namespace WeatherService.Api.Mapping
{
    public class ResponseMapping : Profile
    {
        #region Constructor

        public ResponseMapping()
        {
            CreateMap<CityServiceModel, CityWithWeatherResponseModel>();
            CreateMap<WeatherServiceModel, WeatherItemResponseModel>();
            CreateMap<WindServiceModel, WindResponseModel>();
        }

        #endregion
    }
}
