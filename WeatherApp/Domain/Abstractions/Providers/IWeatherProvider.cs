using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Providers
{
    public interface IWeatherProvider
    {
        Weather FindByCityId(int cityId);
    }
}
