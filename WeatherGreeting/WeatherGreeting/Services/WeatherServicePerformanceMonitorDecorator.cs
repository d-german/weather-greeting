using System;
using System.Diagnostics;
using System.Threading.Tasks;
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

        public async Task<WeatherData> FetchWeatherDataAsync(MapPoint mapPoint, DateTime dateTime)
        {
            _stopwatch.Restart();
            var weatherData = await _weatherServiceDecoratee.FetchWeatherDataAsync(mapPoint, dateTime);
            Console.WriteLine($"Retrieving weather data took {_stopwatch.ElapsedMilliseconds} ms.");

            return weatherData;
        }
    }
}
