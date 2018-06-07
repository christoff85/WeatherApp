using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Providers
{
    public interface IWeatherConditionsProvider
    {
        WeatherConditions FindByCityId(int cityId);
    }
}
