#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WeatherService.Services.Services;
using WeatherService.Services.Services.Interfaces;
using Xunit;

#endregion

namespace WeatherService.Tests.Test
{
    public class IntegrationServiceTest
    {
        #region Private field(s)

        private IIntegrationService IntegrationService { get; set; }

        #endregion

        #region Constructor

        public IntegrationServiceTest()
        {
            var factory = new NullLoggerFactory();
            var logger = new Logger<IntegrationService>(factory);
            IntegrationService = new IntegrationService(logger);
        }

        #endregion

        #region Test

        [Fact]
        public async Task Should_Make_Call_To_Api()
        {
            // Act

            var result = await IntegrationService.GetWeatherForCoordinates(22, 55);

            // Assert

            result.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(24);
        }

        #endregion
    }
}
