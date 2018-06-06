using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IWeatherConditionsProvider
    {
        WeatherConditions FindByCityId(int cityId);
    }
}
