using System.Data.Entity.Migrations;

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
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
