﻿using System;
using System.Threading.Tasks;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Models;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    public class OpenWeatherWebClient : IWeatherProvider
    {
        private readonly IHttpClient _httpClient;
        private readonly IWeatherJsonDeserializer _deserializer;
        private readonly IWeatherPathBuilder _pathBuilder;

        public OpenWeatherWebClient(IHttpClient httpClient, IWeatherJsonDeserializer deserializer, IWeatherPathBuilder pathBuilder)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
            _pathBuilder = pathBuilder ?? throw new ArgumentNullException(nameof(pathBuilder));
        }

        public async Task<Weather> FindByCityIdAsync(int cityId)
        {
            var query = $"weather?id={cityId}&units=metric";
            var fullPath = _pathBuilder.GetFullPath(query);
            var responseContent = await _httpClient.GetResponseContentAsync(fullPath);

            return _deserializer.Deserialize(responseContent);
        }
    }
}