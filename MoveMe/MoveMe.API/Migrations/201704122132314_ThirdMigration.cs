namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobDetails", "MoveOut", c => c.DateTime());
            AlterColumn("dbo.JobDetails", "MoveIn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobDetails", "MoveIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobDetails", "MoveOut", c => c.DateTime(nullable: false));
        }
    }
}
