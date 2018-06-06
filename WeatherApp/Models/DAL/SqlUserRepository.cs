using WeatherApp.Models.Domain;

namespace WeatherApp.Models.DAL
{
    public class SqlUserRepository : SqlBaseRepository<User, UserEntity>, IUserRepository
    {
        public SqlUserRepository(WeatherAppContext context) : base(context)
        {
        }
    }
}