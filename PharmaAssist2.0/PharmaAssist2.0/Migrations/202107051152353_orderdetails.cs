namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "LoginId", "dbo.Logins");
            DropIndex("dbo.Orders", new[] { "LoginId" });
            AddColumn("dbo.OrderDetails", "InvoiceNumber", c => c.String());
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "ConsumerId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ConsumerId", c => c.Int());
            AddColumn("dbo.Orders", "InvoiceNumber", c => c.String());
            CreateIndex("dbo.OrderDetails", "ConsumerId");
            CreateIndex("dbo.Orders", "ConsumerId");
            AddForeignKey("dbo.OrderDetails", "ConsumerId", "dbo.Consumers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ConsumerId", "dbo.Consumers", "Id");
            DropColumn("dbo.Orders", "LoginId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "LoginId", c => c.Int());
            DropForeignKey("dbo.Orders", "ConsumerId", "dbo.Consumers");
            DropForeignKey("dbo.OrderDetails", "ConsumerId", "dbo.Consumers");
            DropIndex("dbo.Orders", new[] { "ConsumerId" });
            DropIndex("dbo.OrderDetails", new[] { "ConsumerId" });
            DropColumn("dbo.Orders", "InvoiceNumber");
            DropColumn("dbo.Orders", "ConsumerId");
            DropColumn("dbo.OrderDetails", "ConsumerId");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.OrderDetails", "InvoiceNumber");
            CreateIndex("dbo.Orders", "LoginId");
            AddForeignKey("dbo.Orders", "LoginId", "dbo.Logins", "Id");
        }
    }
}
