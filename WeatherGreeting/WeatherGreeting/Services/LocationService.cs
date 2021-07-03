using System.Collections.Generic;
using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public class LocationService
    {
        private readonly Dictionary<string, MapPoint> _mapPoints = new Dictionary<string, MapPoint>
        {
            ["Raymore Missouri"] = new MapPoint
            {
                Latitude = 38.804131,
                Longitude = -94.452919
            },
            ["Overland Park Kansas"] = new MapPoint
            {
                Latitude = 38.974819,
                Longitude = -94.683601
            }
        };

        public MapPoint GetLocation(string city)
        {
            return _mapPoints[city];
        }
    }
}
