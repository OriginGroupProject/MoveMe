namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class take53 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Companies", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.JobDetails", "FromLocation", c => c.Geography());
            AddColumn("dbo.JobDetails", "ToLocation", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobDetails", "ToLocation");
            DropColumn("dbo.JobDetails", "FromLocation");
            DropColumn("dbo.Companies", "Longitude");
            DropColumn("dbo.Companies", "Latitude");
        }
    }
}
