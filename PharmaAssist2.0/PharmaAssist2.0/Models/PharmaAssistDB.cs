using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PharmaAssist2._0.Models
{
    public class PharmaAssistDB : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            //base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<DeliveryMan> DeliveryMens { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProblemComment> ProblemComments { get; set; }
        public DbSet<ProblemPost> ProblemPosts { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Slot> Slots { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Specialist> Specialists { get; set; }


    }
}