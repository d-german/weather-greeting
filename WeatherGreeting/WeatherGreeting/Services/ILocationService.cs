using WeatherGreeting.Models;

namespace WeatherGreeting.Services
{
    public interface ILocationService
    {
        MapPoint GetLocation(string location);
    }
}