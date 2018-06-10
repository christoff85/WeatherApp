using WeatherApp.Domain.Models;

namespace WeatherApp.Providers.Abstractions.WeatherWebClient
{
    public interface IWeatherJsonDeserializer
    {
        Weather Deserialize(string weatherJsonText);
    }
}