using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public class WeatherConditionsWebClient : IWeatherConditionsWebClient
    {
        private readonly HttpClient _httpClient;

        public WeatherConditionsWebClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            var address = ConfigurationManager.AppSettings["BaseAddress"];
            var uri = new Uri(address);
            _httpClient.BaseAddress = uri;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            var response = _httpClient.GetAsync($"weather?id=2172797&APPID={ConfigurationManager.AppSettings["ApiKey"]}");

            return new WeatherConditions()
            {
                Location = "Warsaw",
                Temperature = 7,
                MaxTemperature = 15,
                MinTemperature = 2,
                Humidity = 81,
                Pressure = 1012
            };
        }
    }
}