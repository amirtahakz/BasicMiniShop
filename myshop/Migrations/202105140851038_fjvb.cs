namespace myshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fjvb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NumbersOfProduct", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "NumbersOfProduct");
        }
    }
}
