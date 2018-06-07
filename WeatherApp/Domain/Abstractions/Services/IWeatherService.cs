using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Services
{
    public interface IWeatherService
    {
        Weather GetLastStoredWeather(int cityId);
        Weather GetById(int id);
        Weather GetCurrentWeather(int cityId);
    }
}