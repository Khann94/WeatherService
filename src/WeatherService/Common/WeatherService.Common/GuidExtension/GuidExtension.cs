#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Common.GuidExtension
{
    public static class GuidExtension
    {
        #region Public methods

        public static bool IsEmpty(this Guid guid)
        {
            return guid.Equals(Guid.Empty);
        }

        #endregion
    }
}
