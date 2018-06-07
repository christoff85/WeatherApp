using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Services
{
    public interface IUserService
    {
        User LoginUser(User user);
        User CreateUser(User user);
    }
}
