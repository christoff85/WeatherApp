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

        public bool UserNameExists(string userName)
        {
            return Entities.Any(u => u.UserName == userName);
        }

        public User GetUserByUserName(string userName)
        {
            var entity = Entities.Single(u => u.UserName.Equals(userName));
            return MapFromEntity(entity);
        }
    }
}