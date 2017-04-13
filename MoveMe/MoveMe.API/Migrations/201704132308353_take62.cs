namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class take62 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Location", c => c.Geography());
            DropColumn("dbo.Companies", "Latitude");
            DropColumn("dbo.Companies", "Longitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Companies", "Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Companies", "Location");
        }
    }
}
