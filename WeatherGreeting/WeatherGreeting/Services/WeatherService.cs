﻿using System;
using System.Threading;
using System.Threading.Tasks;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> FetchWeatherData(MapPoint mapPoint, DateTime dateTime);
    }

    public class WeatherService : IWeatherService
    {
        private readonly Random _randomGenerator = new Random();

        public Task<WeatherData> FetchWeatherData(MapPoint mapPoint, DateTime dateTime)
        {
            Thread.Sleep(_randomGenerator.Next(50, 500));
            return Task.Run(() => new WeatherData
            {
                Location = mapPoint,
                Temperature = _randomGenerator.Next(-10, 110),
                Humidity = _randomGenerator.Next(0, 100),
                Precipitation = _randomGenerator.Next(0, 100),
                UvIndex = _randomGenerator.Next(0, 10),
                DateTime = dateTime
            });
        }
    }
}
