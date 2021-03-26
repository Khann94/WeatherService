#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Services.Models
{
    public class WeatherIntegrationServiceModel
    {
        #region Constructor

        public WeatherIntegrationServiceModel()
        {
            DataSeries = new List<WeatherServiceModel>();
        }

        #endregion


        #region Public properties

        public string Product { get; set; }

        public long Init { get; set; }

        public List<WeatherServiceModel> DataSeries { get; set; }

        #endregion
    }
}
