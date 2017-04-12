namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "JobDetailId" });
            AlterColumn("dbo.Orders", "JobDetailId", c => c.Int());
            CreateIndex("dbo.Orders", "JobDetailId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", new[] { "JobDetailId" });
            AlterColumn("dbo.Orders", "JobDetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "JobDetailId");
        }
    }
}
