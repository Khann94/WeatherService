#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Services.Models
{
    public class WindServiceModel
    {
        #region Public properties

        public string Direction { get; set; }

        public int Speed { get; set; }

        #endregion
    }
}
