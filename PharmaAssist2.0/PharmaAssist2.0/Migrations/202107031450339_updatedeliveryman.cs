namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedeliveryman : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DeliveryMen", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryMen", "Password", c => c.String(nullable: false));
        }
    }
}
