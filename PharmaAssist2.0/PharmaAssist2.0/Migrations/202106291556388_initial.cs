namespace PharmaAssist2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Consumers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ConsumerId = c.Int(nullable: false),
                        SlotId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumers", t => t.ConsumerId, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Slots", t => t.SlotId, cascadeDelete: true)
                .Index(t => t.ConsumerId)
                .Index(t => t.SlotId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LoginId = c.Int(),
                        SpecialistId = c.Int(),
                        Email = c.String(),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Fee = c.Int(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId)
                .ForeignKey("dbo.Specialists", t => t.SpecialistId)
                .Index(t => t.LoginId)
                .Index(t => t.SpecialistId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Specialists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Slots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DoctorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.ProblemPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ConsumerId = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumers", t => t.ConsumerId, cascadeDelete: true)
                .Index(t => t.ConsumerId);
            
            CreateTable(
                "dbo.DeliveryMen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Salary = c.Int(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.ProblemComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        LoginId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId, cascadeDelete: true)
                .Index(t => t.LoginId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ManagerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(),
                        Brandname = c.String(),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Totalprice = c.Int(nullable: false),
                        Power = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                        Brandname = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Power = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Managers", t => t.ManagerId, cascadeDelete: true)
                .Index(t => t.ManagerId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginId = c.Int(),
                        OrderDate = c.DateTime(nullable: false),
                        Totalprice = c.Int(nullable: false),
                        StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.LoginId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.LoginId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DeliveryManId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryMen", t => t.DeliveryManId, cascadeDelete: true)
                .Index(t => t.DeliveryManId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zones", "DeliveryManId", "dbo.DeliveryMen");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Orders", "StatusId", "dbo.Status");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Products", "ManagerId", "dbo.Managers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProblemComments", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Managers", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.DeliveryMen", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.ProblemPosts", "ConsumerId", "dbo.Consumers");
            DropForeignKey("dbo.Consumers", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Slots", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "SlotId", "dbo.Slots");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "SpecialistId", "dbo.Specialists");
            DropForeignKey("dbo.Doctors", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.BlogPosts", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "ConsumerId", "dbo.Consumers");
            DropForeignKey("dbo.BlogComments", "LoginId", "dbo.Logins");
            DropForeignKey("dbo.Admins", "LoginId", "dbo.Logins");
            DropIndex("dbo.Zones", new[] { "DeliveryManId" });
            DropIndex("dbo.Orders", new[] { "StatusId" });
            DropIndex("dbo.Orders", new[] { "LoginId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "ManagerId" });
            DropIndex("dbo.ProblemComments", new[] { "LoginId" });
            DropIndex("dbo.Managers", new[] { "LoginId" });
            DropIndex("dbo.DeliveryMen", new[] { "LoginId" });
            DropIndex("dbo.ProblemPosts", new[] { "ConsumerId" });
            DropIndex("dbo.Slots", new[] { "DoctorId" });
            DropIndex("dbo.BlogPosts", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "SpecialistId" });
            DropIndex("dbo.Doctors", new[] { "LoginId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "SlotId" });
            DropIndex("dbo.Appointments", new[] { "ConsumerId" });
            DropIndex("dbo.Consumers", new[] { "LoginId" });
            DropIndex("dbo.BlogComments", new[] { "LoginId" });
            DropIndex("dbo.Admins", new[] { "LoginId" });
            DropTable("dbo.Zones");
            DropTable("dbo.Status");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            DropTable("dbo.ProblemComments");
            DropTable("dbo.Managers");
            DropTable("dbo.DeliveryMen");
            DropTable("dbo.ProblemPosts");
            DropTable("dbo.Slots");
            DropTable("dbo.Specialists");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
            DropTable("dbo.Consumers");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Logins");
            DropTable("dbo.Admins");
        }
    }
}
