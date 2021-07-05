namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Logins", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logins", "Type", c => c.String(nullable: false));
        }
    }
}
