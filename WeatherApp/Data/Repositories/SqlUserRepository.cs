using System.Linq;
using WeatherApp.Data.Entities;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Models;

namespace WeatherApp.Data.Repositories
{
    public class SqlUserRepository : SqlBaseRepository<User, UserEntity>, IUserRepository
    {
        public SqlUserRepository(WeatherAppContext context) : base(context)
        {
        }

        public User GetSingleOrDefault(string userName, string password)
        {
            var entity = Entities.SingleOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password));
            return MapFromEntity(entity);
        }

        public bool UserNameExists(string userName)
        {
            return Entities.Any(u => u.UserName.Equals(userName));
        }

        public User GetUserByUserName(string userName)
        {
            var entity = Entities.Single(u => u.UserName.Equals(userName));
            return MapFromEntity(entity);
        }

        public void CreateUser(string userName, string password, bool isAdmin)
        {
            var entity = new UserEntity
            {
                UserName = userName,
                Password = password,
                IsAdmin = isAdmin
            };

            Entities.Add(entity);
        }
    }
}