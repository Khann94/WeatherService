#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Common.GuidExtension;

#endregion

namespace WeatherService.Database.Entity
{
    public class Weather : BaseEntity
    {
        #region Public 

        public Weather()
        {
            ExternalId = Guid.NewGuid();
        }

        #endregion

        #region Public properties

        public long CityId { get; set; }

        public City City { get; set; }

        public int Timepoint { get; set; }

        public int CloudCover { get; set; }

        public int Seeing { get; set; }

        public int Transparency { get; set; }

        public int LiftedIndex { get; set; }

        public int Rh2m { get; set; }

        public int Temp2m { get; set; }

        public string PrecType { get; set; }

        public Wind Wind10m { get; set; }

        #endregion
    }
}
