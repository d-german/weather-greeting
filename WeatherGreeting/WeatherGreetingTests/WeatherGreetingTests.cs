using System;
using NUnit.Framework;
using WeatherGreeting.Models;
using WeatherGreeting.Services;

namespace WeatherGreetingTests
{
    internal class MockWeatherService : IWeatherService
    {
        internal WeatherData MockWeatherData { get; set; }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            return MockWeatherData;
        }
    }

    internal class MockLocationService : ILocationService
    {
        internal MapPoint MockMapPoint { get; set; }

        public MapPoint GetLocation(string location)
        {
            return MockMapPoint;
        }
    }

    internal class MockGreetingService : IGreetingService
    {
        internal string MockGreetingToVerify { get; set; }

        public void TransmitGreeting(string greeting)
        {
            MockGreetingToVerify = greeting;
        }
    }

    public record WeatherGreetingTestCase
    {
        public double Temperature { get; init; }
        public DateTime DateTime { get; init; }
        public int UvIndex { get; init; }
        public string ExpectedResult { get; init; }
    }

    [TestFixture]
    public class WeatherGreetingTests
    {
        private static WeatherGreetingTestCase[] _weatherGreetingTestCases =
        {
            // MorningHotLowUvIndexTest
            new()
            {
                Temperature = 100,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"), // 9AM needs to be morning
                UvIndex = 1,
                ExpectedResult = "Good morning. The current temperature is 100 degrees fahrenheit. It's hot out there, drink plenty of water."
            },
            // MorningHotMediumUvIndexTest
            new()
            {
                Temperature = 100,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"), // 9AM needs to be morning
                UvIndex = 4,
                ExpectedResult = "Good morning. The current temperature is 100 degrees fahrenheit. It's hot out there, drink plenty of water. Consider wearing sunscreen."
            }

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
        };

        [TestCaseSource(nameof(_weatherGreetingTestCases))]
        public void WeatherGreetingTest(WeatherGreetingTestCase testCase)
        {
            var mockWeatherService = new MockWeatherService
            {
                MockWeatherData = new WeatherData
                {
                    Temperature = testCase.Temperature,
                    DateTime = testCase.DateTime,
                    UvIndex = testCase.UvIndex
                }
            };

            var mockLocationService = new MockLocationService
            {
                MockMapPoint = new MapPoint() // don't care can be any value
            };

            var mockGreetingService = new MockGreetingService();

            var sut = new WeatherGreeting.WeatherGreeting(mockGreetingService, mockWeatherService, mockLocationService);

            var actualGreeting = sut.TransmitGreeting(string.Empty, DateTime.Now);
            var expectedGreeting = testCase.ExpectedResult;
            var actualGreetingServiceGreeting = mockGreetingService.MockGreetingToVerify;

            Assert.That(actualGreeting, Is.EqualTo(expectedGreeting));
            Assert.That(actualGreetingServiceGreeting, Is.EqualTo(expectedGreeting));
        }
    }
}
