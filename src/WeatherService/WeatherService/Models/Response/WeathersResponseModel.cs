#region Usings

using System.Collections.Generic;

#endregion

namespace WeatherService.Api.Models.Response
{
    public class WeathersResponseModel
    {
        #region Public properties

        public List<WeatherItemResponseModel> Weathers { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        #endregion
    }
}
