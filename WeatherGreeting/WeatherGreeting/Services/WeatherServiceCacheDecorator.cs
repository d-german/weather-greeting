using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherGreeting.Models;
using Microsoft.Extensions.Caching.Memory;

namespace WeatherGreeting.Services
{
    public class WeatherServiceCacheDecorator : IWeatherService
    {
        private readonly IWeatherService _weatherServiceDecoratee;
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions;
        private readonly SemaphoreSlim _cacheLock = new SemaphoreSlim(initialCount: 1, maxCount: 1);

        public WeatherServiceCacheDecorator(IWeatherService weatherService, IMemoryCache memoryCache)
        {
            _weatherServiceDecoratee = weatherService;
            _memoryCache = memoryCache;
            _cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(5))
                .SetSlidingExpiration(TimeSpan.FromSeconds(1));
        }

        public async Task<WeatherData> FetchWeatherDataAsync(MapPoint mapPoint, DateTime dateTime)
        {
            await _cacheLock.WaitAsync();

            try
            {
                if (_memoryCache.TryGetValue<WeatherData>(mapPoint, out var weatherData))
                {
                    Console.WriteLine("Cache Hit.");
                    return weatherData;
                }

                Console.WriteLine("Cache Miss!");

                _memoryCache.Set(mapPoint, await _weatherServiceDecoratee.FetchWeatherDataAsync(mapPoint, dateTime), _cacheEntryOptions);

                return _memoryCache.Get<WeatherData>(mapPoint);
            }
            finally
            {
                _cacheLock.Release();
            }
        }
    }
}
