using System.Net.Http;
using System.Net.Http.Headers;
using WeatherApp.WebServices.WebClient.Abstractions;

namespace WeatherApp.WebServices.WebClient
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

        public HttpResponseMessage Get(string path)
        {
            return _httpClient.GetAsync(path).Result;
        }

    }
}