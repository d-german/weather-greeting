using System;

namespace WeatherGreeting.Models
{
    /// <summary>
    ///     Simple DTO for WeatherData
    /// </summary>
    public class WeatherData
    {
        public MapPoint? Location { get; set; }

        public DateTime? DateTime { get; set; }
        public double? Temperature { get; set; }
        public double? Precipitation { get; set; }
        public double? Humidity { get; set; }
        public int? UvIndex { get; set; }
    }
}
