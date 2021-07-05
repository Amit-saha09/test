namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedeliveryman2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Zones", "DeliveryManId", "dbo.DeliveryMen");
            DropIndex("dbo.Zones", new[] { "DeliveryManId" });
            AddColumn("dbo.DeliveryMen", "ZoneId", c => c.Int(nullable: false));
            CreateIndex("dbo.DeliveryMen", "ZoneId");
            AddForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones", "Id", cascadeDelete: true);
            DropColumn("dbo.Zones", "DeliveryManId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zones", "DeliveryManId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DeliveryMen", "ZoneId", "dbo.Zones");
            DropIndex("dbo.DeliveryMen", new[] { "ZoneId" });
            DropColumn("dbo.DeliveryMen", "ZoneId");
            CreateIndex("dbo.Zones", "DeliveryManId");
            AddForeignKey("dbo.Zones", "DeliveryManId", "dbo.DeliveryMen", "Id", cascadeDelete: true);
        }
    }
}
