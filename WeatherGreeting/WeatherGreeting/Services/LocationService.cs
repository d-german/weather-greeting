using System.Collections.Generic;
using WeatherGreeting.Models;
using static WeatherGreeting.Constants;

namespace WeatherGreeting.Services
{
    public interface ILocationService
    {
        MapPoint GetLocation(string location);
    }

    public class LocationService : ILocationService
    {
        private readonly Dictionary<string, MapPoint> _mapPoints = new Dictionary<string, MapPoint>
        {
            [KansasCityMissouri] = new MapPoint
            {
                Latitude = 39.099789,
                Longitude = -94.578560
            },
            [OverlandParkKansas] = new MapPoint
            {
                Latitude = 38.974819,
                Longitude = -94.683601
            }
        };

        public MapPoint GetLocation(string location)
        {
            return _mapPoints[location];
        }
    }
}
