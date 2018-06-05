using System.Data.Entity;

namespace WeatherApp.Models.DAL
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext() : base("WeatherAppContext")
        {
            
        }
        public DbSet<WeatherConditionsEntity> WeatherConditions { get; set; }

    }
}