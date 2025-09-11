namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_tbls_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        BrandName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(maxLength: 100),
                        BrandId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Stock = c.Int(nullable: false),
                        Unit_Price = c.Single(nullable: false),
                        WareHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WareHouseId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.WareHouseId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        MovementId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        WareHouseId = c.Int(nullable: false),
                        Transaction_Type = c.String(maxLength: 10),
                        Amount = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovementId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WareHouseId)
                .Index(t => t.ItemId)
                .Index(t => t.WareHouseId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WareHouseId = c.Int(nullable: false, identity: true),
                        WareHouseName = c.String(maxLength: 150),
                        WareHouseLocation = c.String(maxLength: 350),
                    })
                .PrimaryKey(t => t.WareHouseId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 15),
                        UserRole = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "WareHouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Items", "WareHouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Movements", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "BrandId", "dbo.Brands");
            DropIndex("dbo.Movements", new[] { "WareHouseId" });
            DropIndex("dbo.Movements", new[] { "ItemId" });
            DropIndex("dbo.Items", new[] { "WareHouseId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "BrandId" });
            DropTable("dbo.Users");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Movements");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Brands");
        }
    }
}
