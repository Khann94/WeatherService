#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Common.Consts
{
    public static class Config
    {
        #region Public properties

        public static string TimeInfoUrl => "http://www.7timer.info/bin/astro.php";

        #endregion
    }
}
