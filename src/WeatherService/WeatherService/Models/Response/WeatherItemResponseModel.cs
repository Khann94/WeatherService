#region Usings

#endregion

namespace WeatherService.Api.Models.Response
{
    public class WeatherItemResponseModel
    {
        #region Public properties

        public int Timepoint { get; set; }

        public int CloudCover { get; set; }

        public int Seeing { get; set; }

        public int Transparency { get; set; }

        public int LiftedIndex { get; set; }

        public int Rh2m { get; set; }

        public int Temp2m { get; set; }

        public string PrecType { get; set; }

        public WindResponseModel Wind10m { get; set; }

        #endregion
    }
}