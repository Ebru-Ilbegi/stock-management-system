namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_userstatu_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserStatus");
        }
    }
}
