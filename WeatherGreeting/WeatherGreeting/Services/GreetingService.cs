using System;

namespace WeatherGreeting.Services
{
    public class GreetingService
    {
        private int _id;

        public void TransmitGreeting(string greeting)
        {
            Console.WriteLine($"#{_id++}:={greeting}");
        }
    }
}
