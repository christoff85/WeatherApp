using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Providers.WeatherWebClient.Abstractions
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
    }
}