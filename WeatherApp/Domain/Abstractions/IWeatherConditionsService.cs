using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IWeatherConditionsService
    {
        WeatherConditions FindByCityId(int cityId);
        WeatherConditions GetById(int id);
    }
}