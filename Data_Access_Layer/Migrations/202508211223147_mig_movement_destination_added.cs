namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_movement_destination_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movements", "Destination", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movements", "Destination");
        }
    }
}
