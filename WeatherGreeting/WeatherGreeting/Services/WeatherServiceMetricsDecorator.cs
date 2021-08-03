using System;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class WeatherServiceMetricsDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;
        public int WeatherServiceRequestCount { get; private set; }

        public WeatherServiceMetricsDecorator(IWeatherService weatherServiceDecoratee)
        {
            _weatherServiceDecoratee = weatherServiceDecoratee;
        }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            WeatherServiceRequestCount++;
            Console.WriteLine($"Number of {nameof(IWeatherService)} requests; {WeatherServiceRequestCount}");
            return _weatherServiceDecoratee.FetchWeatherData(mapPoint, dateTime);
        }
    }
}
