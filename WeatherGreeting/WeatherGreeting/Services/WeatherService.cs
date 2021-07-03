using System;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class WeatherService
    {
        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            var rng = new Random();
            return new WeatherData
            {
                Location = mapPoint,
                Temperature = rng.Next(-10, 110),
                Humidity = rng.Next(0, 100),
                Precipitation = rng.Next(0, 100),
                UvIndex = rng.Next(0, 10),
                DateTime = dateTime
            };
        }
    }
}
