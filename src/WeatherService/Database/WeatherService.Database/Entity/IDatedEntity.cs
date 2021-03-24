#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Database.Entity
{
    public interface IDatedEntity
    {
        #region Public properties

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        #endregion
    }
}
