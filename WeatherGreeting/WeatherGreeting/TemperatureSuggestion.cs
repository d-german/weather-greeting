using System;
using WeatherGreeting.Models;
using static WeatherGreeting.Constants;

namespace WeatherGreeting
{
    public class TemperatureSuggestionBase
    {
        public virtual string GetTemperatureSuggestion(WeatherData weatherData)
        {
            var temperatureSuggestion = string.Empty;

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

            if (temperatureSuggestion.Length < 256)
            {
                return temperatureSuggestion;
            }

            throw new InvalidOperationException();
        }
    }

    public class TemperatureSuggestionExtra : TemperatureSuggestionBase
    {
        /// <summary>
        /// An overriding method with a stronger postcondition causes no harm to a client call that relies on the original postcondition being satisfied after the call.
        /// This does not Violate the LSP
        /// </summary>
        public override string GetTemperatureSuggestion(WeatherData weatherData)
        {
            var temperatureSuggestion = $"{base.GetTemperatureSuggestion(weatherData)} Hello World";

            if (temperatureSuggestion.Length < 128) // this is stronger since <128 is more likely to be false than <256
            {
                return temperatureSuggestion;
            }

            throw new InvalidOperationException();
        }
    }
}
