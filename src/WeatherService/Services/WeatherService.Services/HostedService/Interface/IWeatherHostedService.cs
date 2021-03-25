#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Services.HostedService.Interface
{
    public interface IWeatherHostedService
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
