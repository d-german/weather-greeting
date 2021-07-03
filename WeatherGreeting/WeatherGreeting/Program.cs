using System;

namespace WeatherGreeting
{
    internal static class Program
    {
        private static void Main()
        {
            var greeting = new WeatherGreeting();
            Console.WriteLine("Press Enter to keep going or any other ke to Exit");

            do
            {
                greeting.TransmitGreeting();
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
