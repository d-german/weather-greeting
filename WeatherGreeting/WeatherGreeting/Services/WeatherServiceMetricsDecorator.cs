using System;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class WeatherServiceMetricsDecorator : IWeatherService
    {
        //TODO: A private readonly field to for the decoratee

        public int WeatherServiceRequestCount { get; private set; }

        public WeatherServiceMetricsDecorator(IWeatherService weatherServiceDecoratee)
        {
            //TODO: set the decoratee field here;
        }

        //TODO: Implement the interface
        public WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            //TODO: remove this line or it will throw an exception
            throw new NotImplementedException();
            // increment WeatherServiceRequestCount and print it's result to the console
            // get the weather data then return it.
        }
    }
}
