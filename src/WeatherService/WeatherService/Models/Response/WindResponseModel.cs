#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Api.Models.Response
{
    public class WindResponseModel
    {
        #region Public properties

        public string Direction { get; set; }

        public int Speed { get; set; }

        #endregion
    }
}
