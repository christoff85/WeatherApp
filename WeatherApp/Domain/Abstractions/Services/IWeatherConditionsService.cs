using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Services
{
    public interface IWeatherConditionsService
    {
        WeatherConditions GetLastStoredWeather(int cityId);
        WeatherConditions GetById(int id);
        WeatherConditions GetCurrentWeather(int cityId);
    }
}