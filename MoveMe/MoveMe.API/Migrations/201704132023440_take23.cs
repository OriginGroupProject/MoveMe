namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class take23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.RequiredEquipments", "JobDetailId", "dbo.JobDetails");
            DropForeignKey("dbo.RequiredEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Inventories", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Inventories", new[] { "CompanyId" });
            DropIndex("dbo.Inventories", new[] { "EquipmentId" });
            DropIndex("dbo.RequiredEquipments", new[] { "JobDetailId" });
            DropIndex("dbo.RequiredEquipments", new[] { "EquipmentId" });
            DropColumn("dbo.JobDetails", "Over400");
            DropColumn("dbo.JobDetails", "PackingAssistance");
            DropColumn("dbo.JobDetails", "ProtectiveMaterial");
            DropTable("dbo.Inventories");
            DropTable("dbo.Equipments");
            DropTable("dbo.RequiredEquipments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RequiredEquipments",
                c => new
                    {
                        RequiredEquipmentId = c.Int(nullable: false, identity: true),
                        JobDetailId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequiredEquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        Tool = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            AddColumn("dbo.JobDetails", "ProtectiveMaterial", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobDetails", "PackingAssistance", c => c.Boolean(nullable: false));
            AddColumn("dbo.JobDetails", "Over400", c => c.Boolean(nullable: false));
            CreateIndex("dbo.RequiredEquipments", "EquipmentId");
            CreateIndex("dbo.RequiredEquipments", "JobDetailId");
            CreateIndex("dbo.Inventories", "EquipmentId");
            CreateIndex("dbo.Inventories", "CompanyId");
            AddForeignKey("dbo.Inventories", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            AddForeignKey("dbo.RequiredEquipments", "EquipmentId", "dbo.Equipments", "EquipmentId", cascadeDelete: true);
            AddForeignKey("dbo.RequiredEquipments", "JobDetailId", "dbo.JobDetails", "JobDetailId", cascadeDelete: true);
            AddForeignKey("dbo.Inventories", "EquipmentId", "dbo.Equipments", "EquipmentId", cascadeDelete: true);
        }
    }
}
