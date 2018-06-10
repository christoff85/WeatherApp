using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Providers.Abstractions.WeatherWebClient
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
    }
}