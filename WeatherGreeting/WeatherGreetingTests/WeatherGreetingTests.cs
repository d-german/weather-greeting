using System;
using Moq;
using NUnit.Framework;
using WeatherGreeting.Models;
using WeatherGreeting.Services;

namespace WeatherGreetingTests
{
    [TestFixture]
    public class WeatherGreetingTests
    {
        private Mock<IWeatherService> _mockWeatherService;
        private Mock<ILocationService> _mockLocationService;
        private Mock<IGreetingService> _mockGreetingService;

        [SetUp]
        public void Init()
        {
            _mockWeatherService = new Mock<IWeatherService>();
            _mockGreetingService = new Mock<IGreetingService>();
            _mockLocationService = new Mock<ILocationService>();
        }

        // MorningHotLowUvIndexTest
        // MorningHotMediumUvIndexTest
        // MorningHotHighUvIndexTest
        // MorningWarmLowUvIndexTest
        // MorningWarmMediumUvIndexTest
        // MorningWarmHighUvIndexTest

        // AfterNoonHotLowUvIndexTest
        // AfterNoonHotMediumUvIndexTest
        // AfterNoonHotHighUvIndexTest
        // AfterNoonWarmLowUvIndexTest
        // AfterNoonWarmMediumUvIndexTest
        // AfterNoonWarmHighUvIndexTest

        // EveningHotLowUvIndexTest
        // EveningHotMediumUvIndexTest
        // EveningHotHighUvIndexTest
        // EveningWarmLowUvIndexTest
        // EveningWarmMediumUvIndexTest
        // EveningWarmHighUvIndexTest

        [Test]
        public void MorningHotHighUvIndexTest()
        {
            _mockWeatherService.Setup(s => s.FetchWeatherData(It.IsAny<MapPoint>(), It.IsAny<DateTime>())).Returns(new WeatherData
            {
                Temperature = 100,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"), // 9AM needs to be morning
                UvIndex = 10
            });

            _mockLocationService.Setup(s => s.GetLocation(It.IsAny<string>())).Returns(new MapPoint());

            var sut = new WeatherGreeting.WeatherGreeting(
                _mockGreetingService.Object,
                _mockWeatherService.Object,
                _mockLocationService.Object);

            var actualGreeting = sut.TransmitGreeting(string.Empty, DateTime.Now);
            const string expectedGreeting = "Good morning. The current temperature is 100 degrees fahrenheit. " +
                                            "It's hot out there, drink plenty of water. " +
                                            "You definitely should wear sunscreen!";

            Assert.That(actualGreeting, Is.EqualTo(expectedGreeting));

            _mockGreetingService.Verify(s => s.TransmitGreeting(expectedGreeting));
        }
    }
}
