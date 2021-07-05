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

            var timeOfDayGreeting = string.Empty;
            var temperatureStatement = $"The current temperature is {weatherData.Temperature} degrees fahrenheit.";
            var temperatureSuggestion = string.Empty;
            var sunscreenSuggestion = string.Empty;

            if (weatherData.DateTime.HasValue)
            {
                var hour = weatherData.DateTime.Value.Hour;
                if (hour < 12)
                {
                    timeOfDayGreeting = "Good morning.";
                }
                else if (hour < 16)
                {
                    timeOfDayGreeting = "Good after noon.";
                }
                else
                {
                    timeOfDayGreeting = "Good evening.";
                }
            }

            if (weatherData.Temperature.HasValue)
            {
                switch (weatherData.Temperature.Value)
                {
                    // hot
                    case > 80:
                        temperatureSuggestion = "It's hot out there, drink plenty of water.";
                        break;
                    // Warm
                    case > 70:
                        temperatureSuggestion = "Have fun.";
                        break;
                    // Cool
                    case > 60:
                        temperatureSuggestion = "You will want to wear a light jacket.";
                        break;
                    // Cold
                    default:
                        temperatureSuggestion = "You will want to wear a coat.";
                        break;
                }
            }

            if (weatherData.Temperature.HasValue && weatherData.UvIndex.HasValue)
            {
                var temperature = weatherData.Temperature.Value;
                var uvIndex = weatherData.UvIndex.Value;

                if (temperature > 70)
                {
                    if (uvIndex > 3 && uvIndex < 5)
                    {
                        sunscreenSuggestion = "Consider wearing sunscreen.";
                    }
                    else if (uvIndex > 5)
                    {
                        sunscreenSuggestion = "You definitely should wear sunscreen!";
                    }
                }
            }

            _greetingService.TransmitGreeting($"{timeOfDayGreeting} {temperatureStatement} {temperatureSuggestion} {sunscreenSuggestion}");
        }
    }
}
