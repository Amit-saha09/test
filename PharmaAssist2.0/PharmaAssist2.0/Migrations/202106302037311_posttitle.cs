namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posttitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPosts", "Title");
        }
    }
}
