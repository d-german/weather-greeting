using System;
using System.Diagnostics;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class WeatherServicePerformanceMonitorDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;

        /// <summary>
        /// TODO: This is difficult to test, better to create a service for this and inject in via an interface
        /// </summary>
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public WeatherServicePerformanceMonitorDecorator(IWeatherService weatherServiceDecoratee)
        {
            _weatherServiceDecoratee = weatherServiceDecoratee;
        }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            _stopwatch.Restart();
            var weatherData = _weatherServiceDecoratee.FetchWeatherData(mapPoint, dateTime);
            Console.WriteLine($"Retrieving weather data took {_stopwatch.ElapsedMilliseconds} ms.");

            return weatherData;
        }
    }
}
