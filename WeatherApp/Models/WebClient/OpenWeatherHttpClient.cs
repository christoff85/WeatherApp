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

        public HttpResponseMessage Get(string path)
        {
            var fullPath = AppendApiKey(path);
            return _httpClient.GetAsync(fullPath).Result;
        }


        private string AppendApiKey(string path)
        {
            return String.Format($"{path}&APPID={_apiKey}");
        }
    }
}