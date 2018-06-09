namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLondonToWeatherTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Weather (Location ,Temperature, MinTemperature, MaxTemperature, Pressure, Humidity, CityId)
                    VALUES ('London', 16, 14, 17, 1016, 87, 2643743);");
        }
        
        public override void Down()
        {
        }
    }
}
