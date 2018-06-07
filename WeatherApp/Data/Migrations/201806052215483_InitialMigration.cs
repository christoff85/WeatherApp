namespace WeatherApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeatherConditionsEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Temperature = c.Int(nullable: false),
                        MinTemperature = c.Int(nullable: false),
                        MaxTemperature = c.Int(nullable: false),
                        Pressure = c.Int(nullable: false),
                        Humidity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WeatherConditionsEntities");
        }
    }
}
