using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IUserService
    {
        User LoginUser(User user);
        User CreateUser(User user);
    }
}
