namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class take2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Completed");
        }
    }
}
