using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WeatherApp.Models.WebClient
{
    public class OpenWeatherHttpClient : IWeatherHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherHttpClient(HttpClient httpClient, string baseAddress, string apiKey)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //TODO: add Timeout

            _apiKey = apiKey;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var fullPath = AppendApiKey(path);
            return await _httpClient.GetAsync(fullPath);
        }


        private string AppendApiKey(string path)
        {
            return path + _apiKey;
        }
    }
}