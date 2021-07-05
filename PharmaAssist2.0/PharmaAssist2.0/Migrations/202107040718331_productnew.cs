namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productnew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Genericname", c => c.String(nullable: false));
            AddColumn("dbo.Products", "RenalDose", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Administration", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Contraindictions", c => c.String(nullable: false));
            AddColumn("dbo.Products", "PregnancyLactation", c => c.String(nullable: false));
            AddColumn("dbo.Products", "TherapeticClass", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ModeofAction", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Interaction", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Interaction");
            DropColumn("dbo.Products", "ModeofAction");
            DropColumn("dbo.Products", "TherapeticClass");
            DropColumn("dbo.Products", "PregnancyLactation");
            DropColumn("dbo.Products", "Contraindictions");
            DropColumn("dbo.Products", "Administration");
            DropColumn("dbo.Products", "RenalDose");
            DropColumn("dbo.Products", "Genericname");
        }
    }
}
