using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myshop.Models
{
    public class db : DbContext
    {
        public db() : base("constrTest") { }
        public DbSet<MyUser> myusers { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Payment> Payments { set; get; }
        public DbSet<PaymentDetail> paymentdetails { set; get; }
        public DbSet<CategoryName> CategoryNames { set; get; }
        public DbSet<ProductWithCategory> ProductWithCategorys { set; get; }
        public DbSet<ResetPasswordModel> ResetPasswordModels { set; get; }

        public System.Data.Entity.DbSet<myshop.Models.Role> Roles { get; set; }
    }
}