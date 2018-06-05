using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public class WeatherConditionsWebClient : IWeatherConditionsWebClient
    {
        private readonly IWeatherHttpClient _httpClient;
        private readonly IWeatherConditionsJsonDeserializer _deserializer;

        public WeatherConditionsWebClient(IWeatherHttpClient httpClient, IWeatherConditionsJsonDeserializer deserializer)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            var response = _httpClient.Get($"weather?id={cityId}&units=metric");
            var responseContent = response.Content.ReadAsStringAsync().Result;

            return _deserializer.Deserialize(responseContent);
        }
    }
}