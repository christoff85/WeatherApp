using System.Net.Http;

namespace WeatherApp.Models.WebClient
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string path);
    }
}