using AutoMapper;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.DAL
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