using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using DemoWebAPI.Controllers;
using Microsoft.Extensions.Logging;

namespace DemoWebApiTestProject.Controller
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;

        public WeatherForecastControllerTests()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_mockLogger.Object);
        }

        [Fact]
        public void Get_ShouldReturnFiveWeatherForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result); // Ensure result is not null
            Assert.Equal(5, result.Count()); // Verify we get exactly 5 forecasts
        }

        [Fact]
        public void Get_ShouldReturnForecastsWithValidData()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            Assert.All(result, forecast =>
            {
                Assert.InRange(forecast.TemperatureC, -20, 55); // Ensure temperature is within valid range
                Assert.Contains(forecast.Summary, WeatherForecastController.Summaries); // Ensure summary is valid
            });
        }

        [Fact]
        public void GetNew_ShouldReturnFiveWeatherForecasts()
        {
            // Act
            var result = _controller.GetNew();

            // Assert
            Assert.NotNull(result); // Ensure result is not null
            Assert.Equal(5, result.Count()); // Verify we get exactly 5 forecasts
        }

        [Fact]
        public void GetNew_ShouldReturnForecastsWithValidData()
        {
            // Act
            var result = _controller.GetNew().ToList();

            // Assert
            Assert.All(result, forecast =>
            {
                Assert.InRange(forecast.TemperatureC, -20, 55); // Ensure temperature is within valid range
                Assert.Contains(forecast.Summary, WeatherForecastController.Summaries); // Ensure summary is valid
            });
        }
    }
}
