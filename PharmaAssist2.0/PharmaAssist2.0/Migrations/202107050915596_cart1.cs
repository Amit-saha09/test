namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "ConsumerId", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "ManagerId");
            DropColumn("dbo.Carts", "CategoryId");
            DropColumn("dbo.Carts", "Image");
            DropColumn("dbo.Carts", "Brandname");
            DropColumn("dbo.Carts", "Power");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Power", c => c.Double(nullable: false));
            AddColumn("dbo.Carts", "Brandname", c => c.String());
            AddColumn("dbo.Carts", "Image", c => c.String());
            AddColumn("dbo.Carts", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "ManagerId", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "ConsumerId");
            DropColumn("dbo.Carts", "ProductId");
        }
    }
}
