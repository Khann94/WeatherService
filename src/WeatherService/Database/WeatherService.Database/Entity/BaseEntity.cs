#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Database.Entity
{
    public abstract class BaseEntity : IDatedEntity
    {
        #region Public properties

        public long Id { get; set; }

        public Guid ExternalId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        #endregion
    }
}
