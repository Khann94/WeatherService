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
        #region Public properties

        public string Name { get; set; }

        public List<Weather> Weathers { get; set; }

        #endregion
    }
}
