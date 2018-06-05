using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public interface IWeatherConditionsJsonDeserializer
    {
        WeatherConditions Deserialize(string weatherJsonText);
    }
}