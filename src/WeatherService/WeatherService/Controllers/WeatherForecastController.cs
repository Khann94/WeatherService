#region Usings

using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WeatherService.Common.Mvc.Attribute;
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
        [Swagger(HttpStatusCode.OK, description: "Get weather for Warsaw")]
        public async Task<IActionResult> GetWeatherForWarsaw()
        {
            return Ok();
        }

        #endregion

        #region PUT

        [HttpPut]
        [Swagger(HttpStatusCode.OK, description: "Get weather by lat long")]
        public async Task<IActionResult> GetWeatherByLatLong()
        {
            return Ok();
        }

        #endregion
    }
}
