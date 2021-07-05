namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeliveryMen", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones");
            DropIndex("dbo.DeliveryMen", new[] { "LoginId" });
            DropIndex("dbo.DeliveryMen", new[] { "ZoneId" });
            AlterColumn("dbo.DeliveryMen", "LoginId", c => c.Int());
            AlterColumn("dbo.DeliveryMen", "ZoneId", c => c.Int());
            CreateIndex("dbo.DeliveryMen", "LoginId");
            CreateIndex("dbo.DeliveryMen", "ZoneId");
            AddForeignKey("dbo.DeliveryMen", "LoginId", "dbo.Logins", "Id");
            AddForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones");
            DropForeignKey("dbo.DeliveryMen", "LoginId", "dbo.Logins");
            DropIndex("dbo.DeliveryMen", new[] { "ZoneId" });
            DropIndex("dbo.DeliveryMen", new[] { "LoginId" });
            AlterColumn("dbo.DeliveryMen", "ZoneId", c => c.Int(nullable: false));
            AlterColumn("dbo.DeliveryMen", "LoginId", c => c.Int(nullable: false));
            CreateIndex("dbo.DeliveryMen", "ZoneId");
            CreateIndex("dbo.DeliveryMen", "LoginId");
            AddForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeliveryMen", "LoginId", "dbo.Logins", "Id", cascadeDelete: true);
        }
    }
}
