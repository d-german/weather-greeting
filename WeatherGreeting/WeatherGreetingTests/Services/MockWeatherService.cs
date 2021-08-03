using System;
using WeatherGreeting.Models;
using WeatherGreeting.Services;

namespace WeatherGreetingTests.Services
{
    internal class MockWeatherService : IWeatherService
    {
        internal WeatherData MockWeatherData { get; set; }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            return MockWeatherData;
        }
    }
}
