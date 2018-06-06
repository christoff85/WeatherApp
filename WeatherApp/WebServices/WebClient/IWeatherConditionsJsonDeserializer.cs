using WeatherApp.Domain.Models;

namespace WeatherApp.WebServices.WebClient
{
    public interface IWeatherConditionsJsonDeserializer
    {
        WeatherConditions Deserialize(string weatherJsonText);
    }
}