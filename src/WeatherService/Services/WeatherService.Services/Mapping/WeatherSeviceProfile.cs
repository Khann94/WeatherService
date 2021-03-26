#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WeatherService.Database.Entity;
using WeatherService.Services.Models;

#endregion

namespace WeatherService.Services.Mapping
{
    public class WeatherSeviceProfile : Profile
    {
        public WeatherSeviceProfile()
        {
            CreateMap<City, CityServiceModel>();
            CreateMap<Weather, WeatherServiceModel>();
            CreateMap<Wind, WindServiceModel>();

            CreateMap<WindServiceModel, Wind>();
            CreateMap<WeatherServiceModel, Weather>();
        }
    }
}
