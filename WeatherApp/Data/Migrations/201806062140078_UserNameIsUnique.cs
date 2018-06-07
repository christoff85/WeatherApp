using System.Data.Entity.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class UserNameIsUnique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Name" });
        }
    }
}
