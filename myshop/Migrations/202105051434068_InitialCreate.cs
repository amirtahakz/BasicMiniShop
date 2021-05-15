namespace myshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryNames",
                c => new
                    {
                        IdCategoryName = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.IdCategoryName);
            
            CreateTable(
                "dbo.ProductWithCategories",
                c => new
                    {
                        IdProductWithCategory = c.Int(nullable: false, identity: true),
                        IdCategoryName = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductWithCategory)
                .ForeignKey("dbo.CategoryNames", t => t.IdCategoryName, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdCategoryName)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.String(),
                        PriceOffer = c.String(),
                        ImageProduct = c.String(),
                    })
                .PrimaryKey(t => t.IdProduct);
            
            CreateTable(
                "dbo.MyUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        NameFamily = c.String(),
                        Password = c.String(),
                        ConfirmEmail = c.Boolean(nullable: false),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        IdPaymentDetail = c.Int(nullable: false, identity: true),
                        NumbersOfProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPaymentDetail);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        IdPayment = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdPayment);
            
            CreateTable(
                "dbo.ResetPasswordModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewPassword = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        ResetCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductWithCategories", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.ProductWithCategories", "IdCategoryName", "dbo.CategoryNames");
            DropIndex("dbo.ProductWithCategories", new[] { "IdProduct" });
            DropIndex("dbo.ProductWithCategories", new[] { "IdCategoryName" });
            DropTable("dbo.ResetPasswordModels");
            DropTable("dbo.Payments");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.MyUsers");
            DropTable("dbo.Products");
            DropTable("dbo.ProductWithCategories");
            DropTable("dbo.CategoryNames");
        }
    }
}
