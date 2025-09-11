namespace Data_Access_Layer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_info_updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserMail", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserRole", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserRole", c => c.String(maxLength: 2));
            DropColumn("dbo.Users", "UserMail");
        }
    }
}
