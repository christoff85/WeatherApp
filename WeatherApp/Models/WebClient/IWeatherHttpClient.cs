using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Models.WebClient
{
    public interface IWeatherHttpClient
    {
        HttpResponseMessage Get(string path);
    }
}