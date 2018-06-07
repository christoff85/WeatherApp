using AutoMapper;
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

        public Weather FindByCityId(int cityId)
        {
            var entity = new WeatherEntity()
            {
                Location = "Warsaw",
                Temperature = 7,
                MaxTemperature = 15,
                MinTemperature = 2,
                Humidity = 81,
                Pressure = 1012
            };

            return Mapper.Map<WeatherEntity, Weather>(entity);
        }
    }
}