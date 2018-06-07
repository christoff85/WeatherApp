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
        public DbSet<WeatherEntity> WeatherConditions { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new WeatherEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}