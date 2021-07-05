using System;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class WeatherService
    {
        private readonly Random _randomGenerator = new Random();

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            return new WeatherData
            {
                Location = mapPoint,
                Temperature = _randomGenerator.Next(-10, 110),
                Humidity = _randomGenerator.Next(0, 100),
                Precipitation = _randomGenerator.Next(0, 100),
                UvIndex = _randomGenerator.Next(0, 10),
                DateTime = dateTime
            };
        }
    }
}
