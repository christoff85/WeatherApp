using Newtonsoft.Json.Linq;
using WeatherApp.Domain.Models;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    public class OpenWeatherJsonDeserializer : IWeatherJsonDeserializer
    {
        private readonly ITimeStampConverter _converter;

        public OpenWeatherJsonDeserializer(ITimeStampConverter converter)
        {
            _converter = converter;
        }
        public Weather Deserialize(string weatherJsonText)
        {
            var weatherJson = JObject.Parse(weatherJsonText);
            var currentWeather = weatherJson["main"];
            var timeStamp = weatherJson["dt"].ToObject<double>();

            return new Weather()
            {
                CityId = weatherJson["id"].ToObject<int>(),
                Location = weatherJson["name"].ToObject<string>(),
                Temperature = currentWeather["temp"].ToObject<int>(),
                MaxTemperature = currentWeather["temp_max"].ToObject<int>(),
                MinTemperature = currentWeather["temp_min"].ToObject<int>(),
                Humidity = currentWeather["humidity"].ToObject<int>(),
                Pressure = currentWeather["pressure"].ToObject<int>(),
                LastUpdate = _converter.ConvertToDateTime(timeStamp)
            };
        }
    }
}