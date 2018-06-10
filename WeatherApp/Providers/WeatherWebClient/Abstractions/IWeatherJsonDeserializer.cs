using WeatherApp.Domain.Models;

namespace WeatherApp.Providers.WeatherWebClient.Abstractions
{
    public interface IWeatherJsonDeserializer
    {
        Weather Deserialize(string weatherJsonText);
    }
}