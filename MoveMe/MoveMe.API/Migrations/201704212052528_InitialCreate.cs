namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "EmailAddress");
            DropColumn("dbo.AspNetUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
        }
    }
}
