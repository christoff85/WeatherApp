using System.Data.Entity.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class TablesRename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserEntities", newName: "Users");
            RenameTable(name: "dbo.WeatherConditionsEntities", newName: "WeatherConditions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.WeatherConditions", newName: "WeatherConditionsEntities");
            RenameTable(name: "dbo.Users", newName: "UserEntities");
        }
    }
}
