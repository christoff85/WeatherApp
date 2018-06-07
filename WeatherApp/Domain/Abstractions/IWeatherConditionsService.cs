using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IWeatherConditionsService
    {
        WeatherConditions GetLastStoredWeather(int cityId);
        WeatherConditions GetById(int id);
        WeatherConditions GetCurrentWeather(int cityId);
    }
}