using WeatherApp.Data;
using WeatherApp.Data.Entities;

namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WeatherAppContext context)
        {
            context.WeatherConditions.AddOrUpdate(new WeatherConditionsEntity()
            {
                Id = 1,
                Location = "Warsaw",
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
