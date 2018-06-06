using WeatherApp.Data.Entities;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Models;

namespace WeatherApp.Data.Repositories
{
    public class SqlUserRepository : SqlBaseRepository<User, UserEntity>, IUserRepository
    {
        public SqlUserRepository(WeatherAppContext context) : base(context)
        {
        }
    }
}