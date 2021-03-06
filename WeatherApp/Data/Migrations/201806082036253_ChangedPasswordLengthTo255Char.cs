namespace WeatherApp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPasswordLengthTo255Char : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
