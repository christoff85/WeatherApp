using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IWeatherRepository : IRepository<Weather>
    {
        bool WeatherExists(int cityId);
        Weather GetSingleOrDefault(int cityId);
    }
}