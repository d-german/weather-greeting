﻿using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    internal static class Program
    {
        private static void Main()
        {
            var serviceProvider = ConfigureServiceProvider();
            Console.WriteLine("Choose Location");
            Console.WriteLine($"1 for {KansasCityMissouri}");
            Console.WriteLine($"2 for {OverlandParkKansas}");

            var location = Console.ReadLine() == "1" ? KansasCityMissouri : OverlandParkKansas;
            // var greeting = new WeatherGreeting(
            //     new GreetingService(),
            //     ConfigureWeatherService(),
            //     new LocationService());
            var greeting = serviceProvider.GetRequiredService<WeatherGreeting>();

            Console.WriteLine("Press Enter to keep going or any other key to Exit");

            do
            {
                greeting.TransmitGreeting(location);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            static IWeatherService ConfigureWeatherService()
            {
                // Manual DI
                return new WeatherServiceCacheDecorator(
                    new WeatherService(),
                    new MemoryCache(
                        new MemoryCacheOptions()));
            }
        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<WeatherGreeting>();
            services.AddSingleton<WeatherService>();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<IOptions<MemoryCacheOptions>, MemoryCacheOptions>();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<IWeatherService>(
                provider => new WeatherServiceCacheDecorator(
                provider.GetRequiredService<WeatherService>(),
                provider.GetRequiredService<IMemoryCache>()));

            return services.BuildServiceProvider();
        }
    }
}
