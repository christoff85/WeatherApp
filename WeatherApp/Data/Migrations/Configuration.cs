using System.Data.Entity.Migrations;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WeatherAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Migrations";
            MigrationsNamespace = @"WeatherApp.Data.Migrations";
        }

        protected override void Seed(WeatherAppContext context)
        {
            context.WeatherConditions.AddOrUpdate(new WeatherEntity()
            {
                Id = 1,
                CityId = 756135,
                Location = "Warsaw",
                Humidity = 100,
                Temperature = 30,
                MinTemperature = 10,
                MaxTemperature = 50,
                Pressure = 980
            });

            context.WeatherConditions.AddOrUpdate(new WeatherEntity()
            {
                Id = 2,
                CityId = 2147714,
                Location = "Sydney",
                Humidity = 100,
                Temperature = 30,
                MinTemperature = 10,
                MaxTemperature = 50,
                Pressure = 980
            });

            context.WeatherConditions.AddOrUpdate(new WeatherEntity()
            {
                Id = 3,
                CityId = 2643743,
                Location = "London",
                Humidity = 100,
                Temperature = 30,
                MinTemperature = 10,
                MaxTemperature = 50,
                Pressure = 980
            });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
