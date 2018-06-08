using System.Data.Entity.ModelConfiguration;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Configurations
{
    public class WeatherEntityConfiguration : EntityTypeConfiguration<WeatherEntity>
    {
        public WeatherEntityConfiguration()
        {
            ToTable("Weather");

            Property(w => w.Location)
                .IsRequired()
                .HasMaxLength(100);

            HasIndex(w => w.CityId)
                .IsUnique();
        }
    }
}