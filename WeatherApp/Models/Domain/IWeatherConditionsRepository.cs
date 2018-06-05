using WeatherApp.Models.DAL;

namespace WeatherApp.Models.Domain
{
    public interface IWeatherConditionsRepository : IRepository<WeatherConditions>
    {
        WeatherConditions FindByCityId(int cityId);
    }
}