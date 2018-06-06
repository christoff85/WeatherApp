using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IWeatherConditionsRepository : IRepository<WeatherConditions>
    {
        WeatherConditions FindByCityId(int cityId);
    }
}