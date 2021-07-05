namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loginadmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "RegistrationStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Logins", "LoginStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "Phone", c => c.String());
            DropColumn("dbo.Admins", "Email");
            DropColumn("dbo.Admins", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Admins", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Phone", c => c.String(nullable: false));
            DropColumn("dbo.Logins", "LoginStatus");
            DropColumn("dbo.Logins", "RegistrationStatus");
        }
    }
}
