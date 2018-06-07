namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedColumnNameToUserNameForUserTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Name" });
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Users", "UserName", unique: true);
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Users", new[] { "UserName" });
            DropColumn("dbo.Users", "UserName");
            CreateIndex("dbo.Users", "Name", unique: true);
        }
    }
}
