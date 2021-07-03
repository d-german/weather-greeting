using System;
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
        private readonly LocationService _locationService = new();

        public void TransmitGreeting(string location)
        {
            var mapPoint = _locationService.GetLocation(location);
            var weatherData = _weatherService.FetchWeatherData(mapPoint, DateTime.Now);

            string greeting = string.Empty;
            if (weatherData.DateTime.HasValue)
            {
                var hour = weatherData.DateTime.Value.Hour;
                if (hour < 12)
                {
                    greeting += "Good morning.";
                }
                else if (hour < 16)
                {
                    greeting += "Good after noon.";
                }
                else
                {
                    greeting += "Good evening.";
                }
            }

            greeting += $" The current temperature is {weatherData.Temperature}";

            if (weatherData.Temperature.HasValue)
            {
                switch (weatherData.Temperature.Value)
                {
                    // hot
                    case > 80:
                        greeting += " It's hot out there, drink plenty of water";
                        break;
                    // Warm
                    case > 70:
                        greeting += " Have fun";
                        break;
                    // Cool
                    case > 60:
                        greeting += " You will want to wear a light jacket.";
                        break;
                    // Cold
                    default:
                        greeting += " You will want to wear a coat.";
                        break;
                }
            }

            _greetingService.TransmitGreeting(greeting);
        }
    }
}
