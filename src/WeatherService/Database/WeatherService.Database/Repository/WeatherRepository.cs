#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Database.Context;
using WeatherService.Database.Repository.Interface;

#endregion

namespace WeatherService.Database.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        #region Public properties

        public WeatherRepository(WeatherContext context)
        {
            Context = context;
        }

        #endregion

        #region Private properties

        private WeatherContext Context { get; set; }

        #endregion

        #region Public method(s)

        #endregion
    }
}
