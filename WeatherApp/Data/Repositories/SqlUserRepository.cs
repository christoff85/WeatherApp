using System;
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
            var entity = Entities.SingleOrDefault(u => u.UserName.Equals(userName, StringComparison.InvariantCulture) 
                                                       && u.Password.Equals(password, StringComparison.InvariantCulture));
            return MapFromEntity(entity);
        }

        public bool UserNameExists(string userName)
        {
            return Entities.Any(u => u.UserName.Equals(userName, StringComparison.InvariantCulture));
        }

        public User GetUserByUserName(string userName)
        {
            var entity = Entities.Single(u => u.UserName.Equals(userName, StringComparison.InvariantCulture));
            return MapFromEntity(entity);
        }

        public void CreateUser(string userName, string password)
        {
            var entity = new UserEntity
            {
                UserName = userName,
                Password = password,
                IsAdmin = false
            };

            Entities.Add(entity);
        }
    }
}