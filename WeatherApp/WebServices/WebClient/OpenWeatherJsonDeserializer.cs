using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;
using WeatherApp.WebServices.WebClient.Abstractions;

namespace WeatherApp.WebServices.WebClient
{
    public class OpenWeatherJsonDeserializer : IWeatherJsonDeserializer
    {
        public Weather Deserialize(string weatherJsonText)
        {
            var weatherJson = JObject.Parse(weatherJsonText);
            var currentWeather = weatherJson["main"];

            return new Weather()
            {
                CityId = weatherJson["id"].ToObject<int>(),
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