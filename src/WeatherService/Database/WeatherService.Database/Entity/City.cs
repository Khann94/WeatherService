#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Database.Entity
{
    public class City : BaseEntity
    {
        #region Constructor(s)

        public City()
        {
            Weathers = new List<Weather>();
        }

        #endregion

        #region Public properties

        public string Name { get; set; }

        public List<Weather> Weathers { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        #endregion
    }
}
