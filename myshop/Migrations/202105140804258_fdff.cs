namespace myshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fdff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentDetails", "ProductPrice", c => c.Double(nullable: false));
            AddColumn("dbo.PaymentDetails", "IdPayment", c => c.Int(nullable: false));
            AddColumn("dbo.PaymentDetails", "IdProduct", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "PaymentConfirmation", c => c.Boolean(nullable: false));
            AddColumn("dbo.Payments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.PaymentDetails", "IdPayment");
            CreateIndex("dbo.PaymentDetails", "IdProduct");
            CreateIndex("dbo.Payments", "UserId");
            AddForeignKey("dbo.Payments", "UserId", "dbo.MyUsers", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.PaymentDetails", "IdPayment", "dbo.Payments", "IdPayment", cascadeDelete: true);
            AddForeignKey("dbo.PaymentDetails", "IdProduct", "dbo.Products", "IdProduct", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentDetails", "IdProduct", "dbo.Products");
            DropForeignKey("dbo.PaymentDetails", "IdPayment", "dbo.Payments");
            DropForeignKey("dbo.Payments", "UserId", "dbo.MyUsers");
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropIndex("dbo.PaymentDetails", new[] { "IdProduct" });
            DropIndex("dbo.PaymentDetails", new[] { "IdPayment" });
            DropColumn("dbo.Payments", "UserId");
            DropColumn("dbo.Payments", "PaymentConfirmation");
            DropColumn("dbo.PaymentDetails", "IdProduct");
            DropColumn("dbo.PaymentDetails", "IdPayment");
            DropColumn("dbo.PaymentDetails", "ProductPrice");
        }
    }
}
