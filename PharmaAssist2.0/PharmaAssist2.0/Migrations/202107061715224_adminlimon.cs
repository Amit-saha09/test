namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminlimon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "LoginId", "dbo.Logins");
            DropIndex("dbo.Admins", new[] { "LoginId" });
            AlterColumn("dbo.Admins", "LoginId", c => c.Int());
            AlterColumn("dbo.Managers", "Image", c => c.String());
            CreateIndex("dbo.Admins", "LoginId");
            AddForeignKey("dbo.Admins", "LoginId", "dbo.Logins", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "LoginId", "dbo.Logins");
            DropIndex("dbo.Admins", new[] { "LoginId" });
            AlterColumn("dbo.Managers", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "LoginId", c => c.Int(nullable: false));
            CreateIndex("dbo.Admins", "LoginId");
            AddForeignKey("dbo.Admins", "LoginId", "dbo.Logins", "Id", cascadeDelete: true);
        }
    }
}
