using Newtonsoft.Json.Linq;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public class WeatherConditionsJsonDeserializer : IWeatherConditionsJsonDeserializer
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