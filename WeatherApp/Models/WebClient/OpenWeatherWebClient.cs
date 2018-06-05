using System;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public class OpenWeatherWebClient : IWeatherConditionsWebClient
    {
        private readonly IHttpClient _httpClient;
        private readonly IWeatherConditionsJsonDeserializer _deserializer;
        private readonly IWeatherPathBuilder _pathBuilder;

        public OpenWeatherWebClient(IHttpClient httpClient, IWeatherConditionsJsonDeserializer deserializer, IWeatherPathBuilder pathBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
            _pathBuilder = pathBuilder ?? throw new ArgumentNullException(nameof(pathBuilder));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            var query = $"weather?id={cityId}&units=metric";
            var fullPath = _pathBuilder.GetFullPath(query);
            var response = _httpClient.Get(fullPath);
            var responseContent = response.Content.ReadAsStringAsync().Result;

            return _deserializer.Deserialize(responseContent);
        }
    }
}