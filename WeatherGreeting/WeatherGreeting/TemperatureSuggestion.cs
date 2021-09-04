using WeatherGreeting.Models;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    public interface ITemperatureSuggestion
    {
        string GetTemperatureSuggestion(WeatherData weatherData);
    }

    public class TemperatureSuggestion : ITemperatureSuggestion
    {
        public string GetTemperatureSuggestion(WeatherData weatherData)
        {
            var temperatureSuggestion = string.Empty;

            if (weatherData.Temperature.HasValue)
            {
                switch (weatherData.Temperature.Value)
                {
                    // hot
                    case > 80:
                        temperatureSuggestion = TemperatureSuggestionHot ;
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

            return temperatureSuggestion;
        }
    }
}
