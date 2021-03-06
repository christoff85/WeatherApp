﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherApp.Providers.Abstractions.WeatherWebClient;

namespace WeatherApp.Providers.WeatherWebClient
{
    public class JsonHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public JsonHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //TODO: add Timeout
        }

        public async Task<string> GetResponseContentAsync(string path)
        {
            var response = await _httpClient.GetAsync(path);
            return await response.Content.ReadAsStringAsync();
        }

    }
}