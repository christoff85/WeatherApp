using AutoMapper;
using WeatherApp.Models.Domain;

namespace WeatherApp.Models.DAL
{
    public class SqlWeatherConditionsRepository : IWeatherConditionsRepository
    {
        private readonly string _connectionString;

        public SqlWeatherConditionsRepository(string connectionString)
        {
            _connectionString = connectionString;
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