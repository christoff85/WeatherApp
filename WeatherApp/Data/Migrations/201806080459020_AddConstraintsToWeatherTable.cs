namespace WeatherApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintsToWeatherTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weather", "Location", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Weather", "CityId", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Weather", new[] { "CityId" });
            AlterColumn("dbo.Weather", "Location", c => c.String());
        }
    }
}
