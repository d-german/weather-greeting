using WeatherGreeting.Services;

namespace WeatherGreeting
{
    /// <summary>
    ///     Fetches the current weather, composes a greeting, then transmits the greeting
    /// </summary>
    public class WeatherGreeting
    {
        private readonly GreetingService _greetingService = new();
        private readonly WeatherService _weatherService = new();

        public void TransmitGreeting()
        {
            _greetingService.TransmitGreeting(ComposeGreeting());
        }

        private string ComposeGreeting()
        {
            var greeting = "Hello World";
            return greeting;
        }
    }
}
