using System.Net.Http;

namespace WeatherApp.WebServices.WebClient.Abstractions
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string path);
    }
}