#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Services.Models
{
    public class WeatherServiceModel
    {
        #region Public properties

        public int Timepoint { get; set; }

        public int CloudCover { get; set; }

        public int Seeing { get; set; }

        public int Transparency { get; set; }

        public int LiftedIndex { get; set; }

        public int Rh2m { get; set; }

        public int Temp2m { get; set; }

        public string PrecType { get; set; }

        public WindServiceModel Wind10m { get; set; }

        #endregion
    }
}
