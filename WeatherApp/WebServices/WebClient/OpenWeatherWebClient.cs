﻿using System;
using WeatherApp.Domain.Abstractions.Providers;
using WeatherApp.Domain.Models;
using WeatherApp.WebServices.WebClient.Abstractions;

namespace WeatherApp.WebServices.WebClient
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

        public Weather FindByCityId(int cityId)
        {
            var query = $"weather?id={cityId}&units=metric";
            var fullPath = _pathBuilder.GetFullPath(query);
            var response = _httpClient.Get(fullPath);
            var responseContent = response.Content.ReadAsStringAsync().Result;

            return _deserializer.Deserialize(responseContent);
        }
    }
}