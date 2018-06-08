using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Services
{
    public interface IUserService
    {
        User LoginUser(string userName, string password);
        User CreateUser(string userName, string password);
    }
}
