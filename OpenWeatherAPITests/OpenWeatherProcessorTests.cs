using System;
using Xunit;
using OpenWeatherAPI;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        [Fact]
        public async void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            openWeatherProcessor.ApiKey = null;
            //Act

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetOneCallAsync);
        }

        [Fact]
        public async void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            //Arrange
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;
            openWeatherProcessor.ApiKey = null;
            //Act

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetCurrentWeatherAsync);
        }
    }
}
