#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Services.Models;

#endregion

namespace WeatherService.Services.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task UpdateWeatherForExistingCities();

        Task<CityServiceModel> GetCityByExternalId(Guid externalId);

        Task<List<WeatherServiceModel>> GetWeatherForCoordinates(double latitude, double longitude);
    }
}
