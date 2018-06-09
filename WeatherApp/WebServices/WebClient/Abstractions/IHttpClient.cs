using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.WebServices.WebClient.Abstractions
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
    }
}