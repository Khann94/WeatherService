#region Usings

using AutoMapper;
using WeatherService.Api.Models.Request;
using WeatherService.Services.Models;

#endregion

namespace WeatherService.Api.Mapping
{
    public class RequestMapping : Profile
    {
        #region Constructor

        public RequestMapping()
        {
            CreateMap<CoordinateRequestModel, CoordinateServiceModel>();
        }

        #endregion
    }
}
