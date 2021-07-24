using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    internal static class Program
    {
        private static async Task Main()
        {
            var greeting = new WeatherGreeting(new GreetingService(),
                ConfigureWeatherService(),
                new LocationService());

            await Task.WhenAll(
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(KansasCityMissouri),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(KansasCityMissouri),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(KansasCityMissouri),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(KansasCityMissouri),
                greeting.TransmitGreeting(OverlandParkKansas),
                greeting.TransmitGreeting(KansasCityMissouri)
            );
        }

        private static IWeatherService ConfigureWeatherService()
        {
            var weatherServiceDecoratee = new WeatherService();
            var weatherServiceCacheDecorator = new WeatherServiceCacheDecorator(weatherServiceDecoratee, new MemoryCache(new MemoryCacheOptions()));
            var weatherServicePerformanceMonitorDecorator = new WeatherServicePerformanceMonitorDecorator(weatherServiceCacheDecorator);
            return weatherServicePerformanceMonitorDecorator;
        }
    }
}
