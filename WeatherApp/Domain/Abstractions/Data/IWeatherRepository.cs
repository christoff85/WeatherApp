using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IWeatherRepository : IRepository<Weather>
    {
        Weather FindByCityId(int cityId);
    }
}