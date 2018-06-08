using System.Linq;
using WeatherApp.Data.Entities;
using WeatherApp.Domain.Abstractions.Data;
using WeatherApp.Domain.Models;

namespace WeatherApp.Data.Repositories
{
    public class SqlWeatherRepository : SqlBaseRepository<Weather, WeatherEntity>, IWeatherRepository
    {
        public SqlWeatherRepository(WeatherAppContext context) : base(context)
        {
        }

        public bool WeatherExists(int cityId)
        {
            return Entities.Any(w => w.CityId == cityId);
        }

        public Weather GetSingleOrDefault(int cityId)
        {
            var entity = Entities.SingleOrDefault(w => w.CityId == cityId);
            return MapFromEntity(entity);
        }
    }
}