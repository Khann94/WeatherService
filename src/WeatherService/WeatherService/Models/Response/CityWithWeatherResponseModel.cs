#region Usings

using System;

#endregion

namespace WeatherService.Api.Models.Response
{
    public class CityWithWeatherResponseModel : WeathersResponseModel
    {
        #region Public properties

        public string Name { get; set; }

        public Guid ExternalId { get; set; }

        #endregion
    }
}
