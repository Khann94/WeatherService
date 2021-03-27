#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using WeatherService.Database.Repository.Interface;
using WeatherService.Services.Models;
using WeatherService.Services.Services;
using WeatherService.Services.Services.Interfaces;
using WeatherService.Tests.Data;
using Xunit;

#endregion

namespace WeatherService.Tests.Test
{
    public class WeatherForecastServiceTest
    {
        #region Private fields

        private IWeatherForecastService WeatherService;
        private Mock<IIntegrationService> MockIntegrationService;
        private Mock<ICityRepository> MockCityRepository;

        #endregion

        #region Constructor

        public WeatherForecastServiceTest()
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddMaps(Assembly.Load("WeatherService.Services"))).CreateMapper();
            MockCityRepository = new Mock<ICityRepository>();
            MockIntegrationService = new Mock<IIntegrationService>();

            var repositoryProvider = new Lazy<ICityRepository>(() => MockCityRepository.Object);
            var integrationProvider = new Lazy<IIntegrationService>(() => MockIntegrationService.Object);
            var mapperProvider = new Lazy<IMapper>(() => mapper);
            var loggerFactory = new NullLoggerFactory();
            var logger = new Logger<WeatherForecastService>(loggerFactory);
            WeatherService = new WeatherForecastService(integrationProvider, repositoryProvider, mapperProvider, logger);
        }

        #endregion

        [Fact]
        public async Task Should_Return_City_With_Weathers_By_External_Id()
        {
            // Arrange
            var cityExternalId = Guid.NewGuid();
            var longitude = 52.23;
            var latitude = 21.01;
            var weatherCount = 2;
            var expectedResult = TestDataProvider.GetCityServiceWithWeathers(cityExternalId, latitude, longitude, weatherCount);
            MockCityRepository.Setup(x => x.GetByExternalIdOrNull(cityExternalId)).ReturnsAsync(TestDataProvider.GetCityWithWeathers(cityExternalId, latitude, longitude, weatherCount));

            // Act
            var result = await WeatherService.GetCityByExternalId(cityExternalId);

            // Assert

            result.Should().NotBeNull();
            result.ExternalId.Should().Be(expectedResult.ExternalId);
            result.Longitude.Should().Be(expectedResult.Longitude);
            result.Latitude.Should().Be(expectedResult.Latitude);
            result.Weathers.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(weatherCount);
            MockCityRepository.Verify(x => x.GetByExternalIdOrNull(cityExternalId), Times.Once);
        }


        [Fact]
        public async Task Should_Return_Weathers()
        {
            // Arrange
            var weatherCount = 5;
            var longitude = 52.23;
            var latitude = 21.01;
            var expectedResult = TestDataProvider.GetWeathers(weatherCount);
            MockIntegrationService.Setup(x => x.GetWeatherForCoordinates(latitude, longitude)).ReturnsAsync(expectedResult);

            // Act
            var result = await WeatherService.GetWeatherForCoordinates(latitude, longitude);

            // Assert

            result.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(weatherCount);
            result.Should().Equal(expectedResult);
            MockIntegrationService.Verify(x => x.GetWeatherForCoordinates(latitude, longitude), Times.Once);
        }
    }
}
