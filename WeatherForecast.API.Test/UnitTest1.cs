using CIUnitTesting.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using WeatherForecast.Communication;

namespace WeatherForecast.API.Test
{
    public class WeatherForecastControllerTests
    {
        private readonly WeatherForecastController _controller;
        public WeatherForecastClient _weatherForecastClient;
        public IConfiguration _configuration;
        public HttpClient _httpClient = new HttpClient();

        public WeatherForecastControllerTests()
        {
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(mockLogger.Object);
            _configuration = new ConfigurationBuilder().AddInMemoryCollection().Build();
            _weatherForecastClient = new WeatherForecastClient(_configuration);
        }

        [Fact]
        public async Task Get_ReturnsFiveWeatherForecasts()
        {
            // Act
            var result = await _weatherForecastClient.GetWeatherForecast(_httpClient);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public void Get_DatesAreInFuture()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(f => f.Date > DateTime.Now));
        }

        [Fact]
        public void Get_TemperatureValuesAreInRange()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(f => f.TemperatureC >= -20 && f.TemperatureC <= 55));
        }

        [Fact]
        public void Get_SummariesAreValid()
        {
            var validSummaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(f => validSummaries.Contains(f.Summary)));
        }

        [Fact]
        public void TestForNothing()
        {
            var validSummaries = new[]
            {
                "aaaaaaaaaaa", "bbbbbbbbbbb", "vcasdvgassdvc", "dasdfasdfga",
            };

            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.All(f => validSummaries.Contains(f.Summary)));
        }
    }
}
