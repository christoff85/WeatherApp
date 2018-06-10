using System;
using WeatherApp.Providers.WeatherWebClient.Abstractions;

namespace WeatherApp.Providers.WeatherWebClient
{
    public class OpenWeatherPathBuilder : IWeatherPathBuilder
    {
        private readonly string _baseAddress;
        private readonly string _apiKey;

        public OpenWeatherPathBuilder(string baseAddress, string apiKey)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public string GetFullPath(string query)
        {
            return $"{_baseAddress}{query}{_apiKey}";
        }
    }
}