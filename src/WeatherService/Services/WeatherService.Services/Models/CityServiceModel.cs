#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WeatherService.Services.Models
{
    public class CityServiceModel
    {
        #region Public properties

        public long Id { get; set; }

        public Guid ExternalId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Name { get; set; }

        public List<WeatherServiceModel> Weathers { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        #endregion
    }
}
