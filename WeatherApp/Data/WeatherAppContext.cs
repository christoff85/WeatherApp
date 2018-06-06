using System.Data.Entity;
using WeatherApp.Data.Configurations;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext() : base("WeatherAppContext")
        { 
        }
        public DbSet<WeatherConditionsEntity> WeatherConditions { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new WeatherConditionsEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}