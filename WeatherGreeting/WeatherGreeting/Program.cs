using System;
using Microsoft.Extensions.Caching.Memory;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Choose Location");
            Console.WriteLine($"1 for {KansasCityMissouri}");
            Console.WriteLine($"2 for {OverlandParkKansas}");

            var location = Console.ReadLine() == "1" ? KansasCityMissouri : OverlandParkKansas;
            var greeting = new WeatherGreeting(new GreetingService(),
                ConfigureWeatherService(),
                new LocationService());
            Console.WriteLine("Press Enter to keep going or any other key to Exit");

            do
            {
                greeting.TransmitGreeting(location);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            IWeatherService ConfigureWeatherService()
            {
                var weatherServiceDecoratee = new WeatherService();
                var weatherServiceCacheDecorator = new WeatherServiceCacheDecorator(weatherServiceDecoratee, new MemoryCache(new MemoryCacheOptions()));
                var weatherServicePerformanceMonitorDecorator = new WeatherServicePerformanceMonitorDecorator(weatherServiceCacheDecorator);
                return weatherServicePerformanceMonitorDecorator;
            }
        }
    }
}
