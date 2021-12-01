using System;
using Microsoft.Extensions.DependencyInjection;
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
            var greeting = serviceProvider.GetRequiredService<WeatherGreeting>();

            Console.WriteLine("Press Enter to keep going or any other key to Exit");

            do
            {
                greeting.TransmitGreeting(location);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        private static ServiceProvider ConfigureServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<WeatherGreeting>();
            services.AddSingleton<IGreetingService, GreetingService>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<IWeatherService>(
                c => ActivatorUtilities.CreateInstance<WeatherServiceMetricsDecorator>(
                    c, ActivatorUtilities.CreateInstance<WeatherService>(c)));

            return services.BuildServiceProvider();
        }
    }
}
