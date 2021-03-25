#region Usings

using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeatherService.Api.Models.Request;
using WeatherService.Api.Models.Response;
using WeatherService.Common.Consts;
using WeatherService.Common.Mvc.Attribute;
using WeatherService.Services.Models;
using WeatherService.Services.Services.Interfaces;

#endregion

namespace WeatherService.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        #region Private fields

        private readonly Lazy<IWeatherForecastService> WeatherForecastServiceProvider;
        private readonly Lazy<IMapper> MapperProvider;

        public WeatherForecastController(
            Lazy<IWeatherForecastService> weatherForecastServiceProvider,
            Lazy<IMapper> mapperProvider)
        {
            WeatherForecastServiceProvider = weatherForecastServiceProvider;
            MapperProvider = mapperProvider;
        }

        #endregion

        #region Private properties

        private IWeatherForecastService WeatherService => WeatherForecastServiceProvider.Value;

        private IMapper Mapper => MapperProvider.Value;

        #endregion

        #region GET

        [HttpGet]
        [Swagger(HttpStatusCode.OK, typeof(CityWithWeatherResponseModel), description: "Get weather for Warsaw")]
        public async Task<IActionResult> GetWeatherForWarsaw()
        {
            var cityWithWeather = await WeatherService.GetByExternalId(SeedExternalIds.WarsawExternalId);
            var mapped = Mapper.Map<CityWithWeatherResponseModel>(cityWithWeather);

            return Ok(mapped);
        }

        #endregion

        #region PUT

        [HttpPut]
        [Swagger(HttpStatusCode.OK, typeof(WeathersResponseModel), description: "Get weather by latitude longitude")]
        public async Task<IActionResult> GetWeatherByCoordinates([FromBody] CoordinateRequestModel requestModel)
        {
            var serviceModel = Mapper.Map<CoordinateServiceModel>(requestModel);

            return Ok(serviceModel);
        }

        #endregion
    }
}
