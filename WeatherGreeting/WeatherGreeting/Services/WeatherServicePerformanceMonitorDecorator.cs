using System;
using System.Diagnostics;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class PerformanceService
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public long ElapsedMilliseconds()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

        public void Restart()
        {
            _stopwatch.Restart();
        }
    }

    public class WeatherServicePerformanceMonitorDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;
        private readonly PerformanceService _performanceService = new PerformanceService();

        public WeatherServicePerformanceMonitorDecorator(IWeatherService weatherServiceDecoratee)
        {
            _weatherServiceDecoratee = weatherServiceDecoratee;
        }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            _performanceService.Restart();
            var weatherData = _weatherServiceDecoratee.FetchWeatherData(mapPoint, dateTime);
            Console.WriteLine($"Retrieving weather data took {_performanceService.ElapsedMilliseconds()} ms.");

            return weatherData;
        }
    }
}
