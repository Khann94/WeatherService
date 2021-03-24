#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Database.Entity
{
    public class Weather : BaseEntity
    {
        #region Public properties

        public long CityId { get; set; }

        public City City { get; set; }

        #endregion
    }
}
