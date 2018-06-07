using System.Data.Entity.ModelConfiguration;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Configurations
{
    public class WeatherEntityConfiguration : EntityTypeConfiguration<WeatherEntity>
    {
        public WeatherEntityConfiguration()
        {
            ToTable("Weather");
        }
    }
}