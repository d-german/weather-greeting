using System;
using WeatherGreeting.Models;
using WeatherGreeting.Services;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    /// <summary>
    ///     Fetches the current weather and location, composes a greeting, then transmits the greeting
    /// </summary>
    public class WeatherGreetingFacade
    {
        private readonly IGreetingService _greetingService;
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;
        private readonly ITemperatureSuggestion _temperatureSuggestion;

        public WeatherGreetingFacade(
            IGreetingService greetingService,
            IWeatherService weatherService,
            ILocationService locationService,
            ITemperatureSuggestion temperatureSuggestion)
        {
            _greetingService = greetingService;
            _weatherService = weatherService;
            _locationService = locationService;
            _temperatureSuggestion = temperatureSuggestion;
        }

        public string TransmitGreeting(string location, DateTime? time = null)
        {
            var mapPoint = _locationService.GetLocation(location);
            var weatherData = _weatherService.FetchWeatherData(mapPoint, time ?? DateTime.Now);

            var temperatureStatement = $"The current temperature is {weatherData.Temperature} degrees fahrenheit.";

            var timeOfDayGreeting = TimeOfDayGreeting(weatherData);

            var temperatureSuggestion = _temperatureSuggestion.GetTemperatureSuggestion(weatherData);

            var sunscreenSuggestion = SunscreenSuggestion(weatherData);

            var greeting = $"{timeOfDayGreeting} {temperatureStatement} {temperatureSuggestion} {sunscreenSuggestion}".Trim();

            _greetingService.TransmitGreeting(greeting);
            return greeting;
        }

        private static string SunscreenSuggestion(WeatherData weatherData)
        {
            var sunscreenSuggestion = string.Empty;

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

            return sunscreenSuggestion;
        }

        private static string TimeOfDayGreeting(WeatherData weatherData)
        {
            var timeOfDayGreeting = string.Empty;

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

            return timeOfDayGreeting;
        }
    }
}
