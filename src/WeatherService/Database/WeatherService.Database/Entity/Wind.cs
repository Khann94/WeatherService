#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Database.Entity
{
    public class Wind
    {
        #region Public properties

        public string Direction { get; set; }

        public int Speed { get; set; }

        #endregion
    }
}
