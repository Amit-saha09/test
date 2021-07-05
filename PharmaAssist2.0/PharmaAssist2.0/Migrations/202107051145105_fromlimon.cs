namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromlimon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "ConsumerId", "dbo.Consumers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "ConsumerId" });
            AddColumn("dbo.Orders", "LoginId", c => c.Int());
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Orders", "LoginId");
            AddForeignKey("dbo.Orders", "LoginId", "dbo.Logins", "Id");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id");
            DropColumn("dbo.OrderDetails", "InvoiceNumber");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.Orders", "ConsumerId");
            DropColumn("dbo.Orders", "InvoiceNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "InvoiceNumber", c => c.String());
            AddColumn("dbo.Orders", "ConsumerId", c => c.Int());
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "InvoiceNumber", c => c.String());
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "LoginId", "dbo.Logins");
            DropIndex("dbo.Orders", new[] { "LoginId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            AlterColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "LoginId");
            CreateIndex("dbo.Orders", "ConsumerId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ConsumerId", "dbo.Consumers", "Id");
        }
    }
}
