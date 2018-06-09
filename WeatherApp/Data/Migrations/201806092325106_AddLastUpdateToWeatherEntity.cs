namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastUpdateToWeatherEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weather", "LastUpdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Weather", "LastUpdate");
        }
    }
}
