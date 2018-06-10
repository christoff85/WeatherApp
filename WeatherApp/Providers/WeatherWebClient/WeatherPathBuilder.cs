using System;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    public class WeatherPathBuilder : IWeatherPathBuilder
    {
        private readonly string _baseAddress;
        private readonly string _apiKey;

        public WeatherPathBuilder(string baseAddress, string apiKey)
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