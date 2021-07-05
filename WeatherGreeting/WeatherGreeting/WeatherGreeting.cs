using System;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    /// <summary>
    ///     Fetches the current weather and location, composes a greeting, then transmits the greeting
    /// </summary>
    public class WeatherGreeting
    {
        private readonly GreetingService _greetingService;
        private readonly WeatherService _weatherService;
        private readonly LocationService _locationService;

        public WeatherGreeting(GreetingService greetingService, WeatherService weatherService, LocationService locationService)
        {
            _greetingService = greetingService;
            _weatherService = weatherService;
            _locationService = locationService;
        }

        public void TransmitGreeting(string location, DateTime? time = null)
        {
            var mapPoint = _locationService.GetLocation(location);
            var weatherData = _weatherService.FetchWeatherData(mapPoint, time ?? DateTime.Now);

            var timeOfDayGreeting = string.Empty;
            var temperatureStatement = $"The current temperature is {weatherData.Temperature} degrees fahrenheit.";
            var temperatureSuggestion = string.Empty;
            var sunscreenSuggestion = string.Empty;

            if (weatherData.DateTime.HasValue)
            {
                var hour = weatherData.DateTime.Value.Hour;
                if (hour < 12)
                {
                    timeOfDayGreeting = TimeOfDayGreetingMorning;
                }
                else if (hour < 16)
                {
                    timeOfDayGreeting = TimeOfDayGreetingAfterNoon;
                }
                else
                {
                    timeOfDayGreeting = TimeOfDayGreetingEvening;
                }
            }

            if (weatherData.Temperature.HasValue)
            {
                switch (weatherData.Temperature.Value)
                {
                    // hot
                    case > 80:
                        temperatureSuggestion = TemperatureSuggestionHot;
                        break;
                    // Warm
                    case > 70:
                        temperatureSuggestion = TemperatureSuggestionWarm;
                        break;
                    // Cool
                    case > 60:
                        temperatureSuggestion = TemperatureSuggestionCool;
                        break;
                    // Cold
                    default:
                        temperatureSuggestion = TemperatureSuggestionCold;
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
                        sunscreenSuggestion = SunscreenSuggestionMedium;
                    }
                    else if (uvIndex > 5)
                    {
                        sunscreenSuggestion = SunscreenSuggestionHigh;
                    }
                }
            }

            _greetingService.TransmitGreeting($"{timeOfDayGreeting} {temperatureStatement} {temperatureSuggestion} {sunscreenSuggestion}");
        }
    }
}
