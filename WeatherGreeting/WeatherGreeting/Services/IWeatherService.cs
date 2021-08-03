using System;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public interface IWeatherService
    {
        WeatherData FetchWeatherData(MapPoint mapPoint, DateTime dateTime);
    }
}