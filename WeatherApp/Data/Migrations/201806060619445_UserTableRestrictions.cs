using System.Data.Entity.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class UserTableRestrictions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserEntities", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserEntities", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserEntities", "Password", c => c.String());
            AlterColumn("dbo.UserEntities", "Name", c => c.String());
        }
    }
}
