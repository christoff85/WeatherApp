using AutoMapper;
using WeatherApp.Data.Entities;
using WeatherApp.Domain.Abstractions;
using WeatherApp.Domain.Models;

namespace WeatherApp.Data.Repositories
{
    public class SqlWeatherConditionsRepository : SqlBaseRepository<WeatherConditions, WeatherConditionsEntity>, IWeatherConditionsRepository
    {
        public SqlWeatherConditionsRepository(WeatherAppContext context) : base(context)
        {
        }

        public WeatherConditions FindByCityId(int cityId)
        {
            var entity = new WeatherConditionsEntity()
            {
                Location = "Warsaw",
                Temperature = 7,
                MaxTemperature = 15,
                MinTemperature = 2,
                Humidity = 81,
                Pressure = 1012
            };

            return Mapper.Map<WeatherConditionsEntity, WeatherConditions>(entity);
        }
    }
}