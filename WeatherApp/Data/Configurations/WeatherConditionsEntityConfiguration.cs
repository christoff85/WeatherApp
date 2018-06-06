using System.Data.Entity.ModelConfiguration;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Configurations
{
    public class WeatherConditionsEntityConfiguration : EntityTypeConfiguration<WeatherConditionsEntity>
    {
        public WeatherConditionsEntityConfiguration()
        {
            ToTable("WeatherConditions");
        }
    }
}