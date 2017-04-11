namespace MoveMe.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Telephone = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Employees = c.Int(nullable: false),
                        Radius = c.Int(nullable: false),
                        OpeningHour = c.String(),
                        ClosingHour = c.String(),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        Tool = c.String(),
                    })
                .PrimaryKey(t => t.EquipmentId);
            
            CreateTable(
                "dbo.RequiredEquipments",
                c => new
                    {
                        RequiredEquipmentId = c.Int(nullable: false, identity: true),
                        JobDetailId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequiredEquipmentId)
                .ForeignKey("dbo.JobDetails", t => t.JobDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.JobDetailId)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        JobDetailId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FromStreetAddress = c.String(),
                        FromCity = c.String(),
                        FromState = c.String(),
                        FromZip = c.String(),
                        ToStreetAddress = c.String(),
                        ToCity = c.String(),
                        ToState = c.String(),
                        ToZip = c.String(),
                        MoveOut = c.DateTime(nullable: false),
                        MoveIn = c.DateTime(nullable: false),
                        NumBedroom = c.Int(nullable: false),
                        NumPooper = c.Int(nullable: false),
                        SqFeet = c.Int(nullable: false),
                        Stairs = c.Int(nullable: false),
                        Elevator = c.Boolean(nullable: false),
                        Over400 = c.Boolean(nullable: false),
                        PackingAssistance = c.Boolean(nullable: false),
                        ProtectiveMaterial = c.Boolean(nullable: false),
                        NumMovers = c.Int(nullable: false),
                        NumHours = c.Int(nullable: false),
                        Distance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobDetailId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        PaymentDetailId = c.Int(nullable: false),
                        Rating = c.Int(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Canceled = c.Boolean(nullable: false),
                        JobDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.JobDetails", t => t.JobDetailId)
                .ForeignKey("dbo.PaymentDetails", t => t.PaymentDetailId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CompanyId)
                .Index(t => t.PaymentDetailId)
                .Index(t => t.JobDetailId);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        PaymentDetailId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CCNumber = c.String(),
                        ExpDate = c.String(),
                        CCV = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.PaymentDetailId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        CompanyId = c.Int(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CompanyId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Inventories", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.RequiredEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.RequiredEquipments", "JobDetailId", "dbo.JobDetails");
            DropForeignKey("dbo.Users", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PaymentDetails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Orders", "PaymentDetailId", "dbo.PaymentDetails");
            DropForeignKey("dbo.Orders", "JobDetailId", "dbo.JobDetails");
            DropForeignKey("dbo.JobDetails", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Inventories", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.Users", new[] { "CustomerId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.PaymentDetails", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "JobDetailId" });
            DropIndex("dbo.Orders", new[] { "PaymentDetailId" });
            DropIndex("dbo.Orders", new[] { "CompanyId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.JobDetails", new[] { "CustomerId" });
            DropIndex("dbo.RequiredEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.RequiredEquipments", new[] { "JobDetailId" });
            DropIndex("dbo.Inventories", new[] { "EquipmentId" });
            DropIndex("dbo.Inventories", new[] { "CompanyId" });
            DropTable("dbo.Users");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.JobDetails");
            DropTable("dbo.RequiredEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.Inventories");
            DropTable("dbo.Companies");
        }
    }
}
