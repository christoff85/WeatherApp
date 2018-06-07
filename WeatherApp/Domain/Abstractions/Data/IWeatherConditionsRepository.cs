using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IWeatherConditionsRepository : IRepository<WeatherConditions>
    {
        WeatherConditions FindByCityId(int cityId);
    }
}