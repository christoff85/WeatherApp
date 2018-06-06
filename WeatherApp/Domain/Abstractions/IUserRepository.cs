using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        bool UserNameExists(string userName);
        User GetUserByUserName(string userName);
    }
}
