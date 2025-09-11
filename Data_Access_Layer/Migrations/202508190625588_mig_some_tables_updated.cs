namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_some_tables_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "BrandStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Items", "ItemStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CategoryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryStatus");
            DropColumn("dbo.Items", "ItemStatus");
            DropColumn("dbo.Brands", "BrandStatus");
        }
    }
}
