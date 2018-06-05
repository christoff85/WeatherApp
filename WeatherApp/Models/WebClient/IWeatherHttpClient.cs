using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Models.WebClient
{
    public interface IWeatherHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string path);
    }
}