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
    public interface IIntegrationService
    {
        Task<List<WeatherServiceModel>> GetWeatherForCoordinates(double latitude, double longitude);
    }
}
