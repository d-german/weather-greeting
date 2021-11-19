using System;
using System.Threading.Tasks;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Choose Location");
            Console.WriteLine($"1 for {KansasCityMissouri}");
            Console.WriteLine($"2 for {OverlandParkKansas}");

            var location = Console.ReadLine() == "1" ? KansasCityMissouri : OverlandParkKansas;
            var greeting = new WeatherGreeting(new GreetingService(), new WeatherService(), new LocationService());
            Console.WriteLine("Press Enter to keep going or any other key to Exit");

            do
            {
                await greeting.TransmitGreeting(location);
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
