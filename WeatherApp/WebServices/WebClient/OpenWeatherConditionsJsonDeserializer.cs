using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;

namespace WeatherApp.WebServices.WebClient
{
    public class OpenWeatherConditionsJsonDeserializer : IWeatherConditionsJsonDeserializer
    {
        public WeatherConditions Deserialize(string weatherJsonText)
        {
            var weatherJson = JObject.Parse(weatherJsonText);
            var currentWeather = weatherJson["main"];

            return new WeatherConditions()
            {
                Location = weatherJson["name"].ToObject<string>(),
                Temperature = currentWeather["temp"].ToObject<int>(),
                MaxTemperature = currentWeather["temp_max"].ToObject<int>(),
                MinTemperature = currentWeather["temp_min"].ToObject<int>(),
                Humidity = currentWeather["humidity"].ToObject<int>(),
                Pressure = currentWeather["pressure"].ToObject<int>()
            };
        }
    }
}