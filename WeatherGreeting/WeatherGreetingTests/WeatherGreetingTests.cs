﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;
using WeatherGreeting.Models;
using WeatherGreeting.Services;

namespace WeatherGreetingTests
{
    internal class MockWeatherService : IWeatherService
    {
        internal WeatherData MockWeatherData { get; set; }

        public Task<WeatherData> FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
           return Task.Run(() =>
            {
                return MockWeatherData;
            });
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

    [TestFixture]
    public class WeatherGreetingTests
    {
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
        public async Task MorningHotHighUvIndexTest()
        {
            var mockWeatherService = new MockWeatherService
            {
                MockWeatherData = new WeatherData
                {
                    Temperature = 100,
                    DateTime = DateTime.Parse("03/01/2009 09:00:00"), // 9AM needs to be morning
                    UvIndex = 10
                }
            };
            var mockLocationService = new MockLocationService
            {
                MockMapPoint = new MapPoint() // don't care can be any value
            };

            var mockGreetingService = new MockGreetingService();

            var sut = new WeatherGreeting.WeatherGreeting(mockGreetingService, mockWeatherService, mockLocationService);

            var actualGreeting = await sut.TransmitGreeting(string.Empty, DateTime.Now);
            const string expectedGreeting = "Good morning. The current temperature is 100 degrees fahrenheit. " +
                                            "It's hot out there, drink plenty of water. " +
                                            "You definitely should wear sunscreen!";
            var actualGreetingServiceGreeting = mockGreetingService.MockGreetingToVerify;

            Assert.That(actualGreeting, Is.EqualTo(expectedGreeting));
            Assert.That(actualGreetingServiceGreeting, Is.EqualTo(expectedGreeting));
        }
    }
}
