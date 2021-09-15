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
            },
            // MorningHotHighUvIndexTest
            new()
            {
                Temperature = 100,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good morning. The current temperature is 100 degrees fahrenheit. It's hot out there, drink plenty of water. You definitely should wear sunscreen!"
            },


            // MorningWarmLowUvIndexTest
            new()
            {
                Temperature = 75,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 1,
                ExpectedResult = "Good morning. The current temperature is 75 degrees fahrenheit. Have fun."
            },
            // MorningWarmMediumUvIndexTest
            new()
            {
                Temperature = 75,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good morning. The current temperature is 75 degrees fahrenheit. Have fun. Consider wearing sunscreen."
            },
            // MorningWarmHighUvIndexTest
            new()
            {
                Temperature = 75,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good morning. The current temperature is 75 degrees fahrenheit. Have fun. You definitely should wear sunscreen!"
            },
            // MorningCoolAnyUvIndexTest
            new()
            {
                Temperature = 65,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good morning. The current temperature is 65 degrees fahrenheit. You will want to wear a light jacket."
            },
            // MorningColdAnyUvIndexTest
            new()
            {
                Temperature = 41,
                DateTime = DateTime.Parse("03/01/2009 09:00:00"),
                UvIndex = 1,
                ExpectedResult = "Good morning. The current temperature is 41 degrees fahrenheit. You will want to wear a coat."
            },

            // AfterNoonHotLowUvIndexTest
            new()
            {
                Temperature = 99,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 1,
                ExpectedResult = "Good after noon. The current temperature is 99 degrees fahrenheit. It's hot out there, drink plenty of water."
            },
            // AfterNoonHotMediumUvIndexTest
            new()
            {
                Temperature = 99,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good after noon. The current temperature is 99 degrees fahrenheit. It's hot out there, drink plenty of water. Consider wearing sunscreen."
            },
            // AfterNoonHotHighUvIndexTest
            new()
            {
                Temperature = 99,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good after noon. The current temperature is 99 degrees fahrenheit. It's hot out there, drink plenty of water. You definitely should wear sunscreen!"
            },
            // AfterNoonWarmLowUvIndexTest
            new()
            {
                Temperature = 73,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 2,
                ExpectedResult = "Good after noon. The current temperature is 73 degrees fahrenheit. Have fun."
            },
            // AfterNoonWarmMediumUvIndexTest
            new()
            {
                Temperature = 73,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good after noon. The current temperature is 73 degrees fahrenheit. Have fun. Consider wearing sunscreen."
            },
            // AfterNoonWarmHighUvIndexTest
            new()
            {
                Temperature = 73,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good after noon. The current temperature is 73 degrees fahrenheit. Have fun. You definitely should wear sunscreen!"
            },
            // AfterNoonCoolAnyUvIndexTest
            new()
            {
                Temperature = 68,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 6,
                ExpectedResult = "Good after noon. The current temperature is 68 degrees fahrenheit. You will want to wear a light jacket."
            },
            // AfterNoonColdAnyUvIndexTest
            new()
            {
                Temperature = 21,
                DateTime = DateTime.Parse("03/01/2009 13:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good after noon. The current temperature is 21 degrees fahrenheit. You will want to wear a coat."
            },
            // EveningHotLowUvIndexTest
            new()
            {
                Temperature = 97,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 3,
                ExpectedResult = "Good evening. The current temperature is 97 degrees fahrenheit. It's hot out there, drink plenty of water."
            },
            // EveningHotMediumUvIndexTest
            new()
            {
                Temperature = 97,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good evening. The current temperature is 97 degrees fahrenheit. It's hot out there, drink plenty of water. Consider wearing sunscreen."
            },
            // EveningHotHighUvIndexTest
            new()
            {
                Temperature = 97,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 7,
                ExpectedResult = "Good evening. The current temperature is 97 degrees fahrenheit. It's hot out there, drink plenty of water. You definitely should wear sunscreen!"
            },
            // EveningWarmLowUvIndexTest
            new()
            {
                Temperature = 79,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 1,
                ExpectedResult = "Good evening. The current temperature is 79 degrees fahrenheit. Have fun."
            },
            // EveningWarmMediumUvIndexTest
            new()
            {
                Temperature = 79,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good evening. The current temperature is 79 degrees fahrenheit. Have fun. Consider wearing sunscreen."
            },
            // EveningWarmHighUvIndexTest
            new()
            {
                Temperature = 79,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 7,
                ExpectedResult = "Good evening. The current temperature is 79 degrees fahrenheit. Have fun. You definitely should wear sunscreen!"
            },
            // EveningCoolAnyUvIndexTest
            new()
            {
                Temperature = 62,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 7,
                ExpectedResult = "Good evening. The current temperature is 62 degrees fahrenheit. You will want to wear a light jacket."
            },
            // EveningColdAnyUvIndexTest
            new()
            {
                Temperature = -5,
                DateTime = DateTime.Parse("03/01/2009 17:00:00"),
                UvIndex = 4,
                ExpectedResult = "Good evening. The current temperature is -5 degrees fahrenheit. You will want to wear a coat."
            },
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
