namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameWeatherConditionsTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WeatherConditions", newName: "Weather");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Weather", newName: "WeatherConditions");
        }
    }
}
