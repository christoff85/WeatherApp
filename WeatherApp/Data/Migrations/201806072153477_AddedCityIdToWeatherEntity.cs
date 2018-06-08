namespace WeatherApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedCityIdToWeatherEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weather", "CityId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weather", "CityId");
        }
    }
}
