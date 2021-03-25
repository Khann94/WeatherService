#region Usings

using FluentValidation;

#endregion

namespace WeatherService.Api.Models.Request
{
    public class CoordinateRequestModel
    {
        #region Public properties

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        #endregion
    }

    #region Validator

    public class CoordinateRequestModelValidator : AbstractValidator<CoordinateRequestModel>
    {
        public CoordinateRequestModelValidator()
        {
            RuleFor(p => p.Latitude)
                .GreaterThanOrEqualTo(-90)
                .LessThanOrEqualTo(90);

            RuleFor(p => p.Longitude)
                .GreaterThanOrEqualTo(-180)
                .LessThanOrEqualTo(180);
        }
    }

    #endregion
}
