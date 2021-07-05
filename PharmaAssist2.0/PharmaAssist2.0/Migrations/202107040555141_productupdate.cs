namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Introduction", c => c.String(nullable: false));
            AddColumn("dbo.Products", "AdultDose", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ChildDose", c => c.String(nullable: false));
            AddColumn("dbo.Products", "SideEffect", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Warnning", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Warnning");
            DropColumn("dbo.Products", "SideEffect");
            DropColumn("dbo.Products", "ChildDose");
            DropColumn("dbo.Products", "AdultDose");
            DropColumn("dbo.Products", "Introduction");
        }
    }
}
