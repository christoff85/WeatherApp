using WeatherApp.Domain.Models;

namespace WeatherApp.Domain.Abstractions.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User GetSingleOrDefault(string userName, string password);
        bool UserNameExists(string userName);
        User GetUserByUserName(string userName);
        void CreateUser(string userName, string password);
    }
}
