using System;
using System.Diagnostics;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public abstract class PerformanceServiceBase
    {
        public abstract long ElapsedMilliseconds();
        public abstract void Restart();

        public virtual void Record(long milliseconds)
        {
            Console.WriteLine($"The operation tool {milliseconds}.");
        }
    }

    public class PerformanceService : PerformanceServiceBase
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public override long ElapsedMilliseconds()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

        public override void Restart()
        {
            _stopwatch.Restart();
        }
    }

    public class WeatherServicePerformanceMonitorDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;
        private readonly PerformanceServiceBase _performanceService;

        public WeatherServicePerformanceMonitorDecorator(IWeatherService weatherServiceDecoratee, PerformanceServiceBase performanceService)
        {
            _weatherServiceDecoratee = weatherServiceDecoratee;
            _performanceService = performanceService;
        }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            _performanceService.Restart();
            var weatherData = _weatherServiceDecoratee.FetchWeatherData(mapPoint, dateTime);
            _performanceService.Record(_performanceService.ElapsedMilliseconds());

            return weatherData;
        }
    }
}
