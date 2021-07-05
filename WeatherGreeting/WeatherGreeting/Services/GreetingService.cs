using System;

namespace WeatherGreeting.Services
{
    public interface IGreetingService
    {
        void TransmitGreeting(string greeting);
    }

    public class GreetingService : IGreetingService
    {
        private int _id;

        public void TransmitGreeting(string greeting)
        {
            Console.WriteLine($"#{_id++}:={greeting}");
        }
    }
}
