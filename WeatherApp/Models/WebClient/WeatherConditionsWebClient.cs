using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.WebClient
{
    public class WeatherConditionsWebClient : IWeatherConditionsWebClient
    {
        private readonly IWeatherHttpClient _httpClient;

        public WeatherConditionsWebClient(IWeatherHttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            var response = _httpClient.GetAsync($"weather?id={cityId}");
            

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