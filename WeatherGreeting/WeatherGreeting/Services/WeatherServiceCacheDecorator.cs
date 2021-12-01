using System;
using WeatherGreeting.Models;
using Microsoft.Extensions.Caching.Memory;

namespace WeatherGreeting.Services
{
    public class WeatherServiceCacheDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;

        public WeatherServiceCacheDecorator(IWeatherService weatherService, IMemoryCache memoryCache)
        {
            _weatherServiceDecoratee = weatherService;
            _memoryCache = memoryCache;
            _cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5))
                .SetSlidingExpiration(TimeSpan.FromSeconds(1));
        }

        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            if (_memoryCache.TryGetValue<WeatherData>(mapPoint, out var weatherData))
            {
                Console.WriteLine("cache hit!");
                return weatherData;
            }

            _memoryCache.Set(mapPoint, _weatherServiceDecoratee.FetchWeatherData(mapPoint, dateTime), _cacheEntryOptions);

            Console.WriteLine("cache miss!");

            return _memoryCache.Get<WeatherData>(mapPoint);
        }
    }
}
