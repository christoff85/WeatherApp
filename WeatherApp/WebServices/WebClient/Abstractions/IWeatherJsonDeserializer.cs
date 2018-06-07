using WeatherApp.Domain.Models;

namespace WeatherApp.WebServices.WebClient.Abstractions
{
    public interface IWeatherJsonDeserializer
    {
        Weather Deserialize(string weatherJsonText);
    }
}