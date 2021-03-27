#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using WeatherService.Database.Entity;
using WeatherService.Services.Models;

#endregion

namespace WeatherService.Tests.Data
{
    public static class TestDataProvider
    {
        #region Public method(s)

        public static CityServiceModel GetCityServiceWithWeathers(Guid externalId, double latitude, double longitude, int weathers)
        {
            var fixture = new Fixture();

            var cityServiceModel = fixture.Build<CityServiceModel>()
                .With(x => x.ExternalId, externalId)
                .With(x => x.Longitude, longitude)
                .With(x => x.Latitude, latitude)
                .With(x => x.Weathers, GetWeathers(weathers))
                .Create();

            return cityServiceModel;
        }

        public static City GetCityWithWeathers(Guid externalId, double latitude, double longitude, int weathers)
        {
            var fixture = new Fixture();

            var cityServiceModel = fixture.Build<City>()
                .With(x => x.ExternalId, externalId)
                .With(x => x.Longitude, longitude)
                .With(x => x.Latitude, latitude)
                .With(x => x.Weathers, GetWeathersEntities(weathers))
                .Create();

            return cityServiceModel;
        }

        public static List<WeatherServiceModel> GetWeathers(int amountOfWeathers)
        {
            var weathers = new List<WeatherServiceModel>();

            for (var i = 0; i < amountOfWeathers; i++)
            {
                weathers.Add(GetWeather());
            }

            return weathers;
        }

        #endregion

        #region Private method(s)

        private static WeatherServiceModel GetWeather()
        {
            var fixture = new Fixture();

            var weather = fixture.Build<WeatherServiceModel>()
                .WithAutoProperties()
                .Create();

            return weather;
        }

        private static List<Weather> GetWeathersEntities(int amountOfWeathers)
        {
            var weathers = new List<Weather>();

            for (var i = 0; i < amountOfWeathers; i++)
            {
                weathers.Add(GetWeatherEntity());
            }

            return weathers;
        }

        private static Weather GetWeatherEntity()
        {
            var fixture = new Fixture();

            var weather = fixture.Build<Weather>()
                .WithAutoProperties()
                .Without(x => x.City)
                .Create();

            return weather;
        }

        #endregion
    }
}
