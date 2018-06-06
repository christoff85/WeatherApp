using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    interface IUserService
    {
        User LoginUser(User user);
        User CreateUser(User user);
    }
}
