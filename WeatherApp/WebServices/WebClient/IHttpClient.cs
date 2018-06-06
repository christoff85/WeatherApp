using System.Net.Http;

namespace WeatherApp.WebServices.WebClient
{
    public interface IHttpClient
    {
        HttpResponseMessage Get(string path);
    }
}