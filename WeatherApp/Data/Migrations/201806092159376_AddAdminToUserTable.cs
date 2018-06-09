namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminToUserTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO users (username, password, isAdmin) VALUES ('Admin', 'hidden_password', 1);");
        }
        
        public override void Down()
        {
        }
    }
}
