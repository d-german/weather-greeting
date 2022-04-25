using System;
using System.IO;

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

    public class GreetingServiceFileWriteDecorator : IGreetingService
    {
        private readonly IGreetingService _greetingServiceDecoratee;

        public GreetingServiceFileWriteDecorator(IGreetingService greetingServiceDecoratee)
        {
            _greetingServiceDecoratee = greetingServiceDecoratee;
        }

        public void TransmitGreeting(string greeting)
        {
            try
            {
                using var file = new FileStream("greeting.txt", FileMode.Append);
                using var writer = new StreamWriter(file);
                writer.WriteLine(greeting);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                _greetingServiceDecoratee.TransmitGreeting(greeting);
            }
        }
    }
}
