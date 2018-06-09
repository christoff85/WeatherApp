using System.Threading.Tasks;
using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Providers
{
    public interface IWeatherProvider
    {
        Task<Weather> FindByCityIdAsync(int cityId);
    }
}
