namespace myshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRole = c.Int(nullable: false),
                        NameFarsi = c.String(),
                        NameEnglish = c.String(),
                    })
                .PrimaryKey(t => t.IdRole);
            
            AddColumn("dbo.MyUsers", "IdRole", c => c.Int());
            CreateIndex("dbo.MyUsers", "IdRole");
            AddForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles", "IdRole");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyUsers", "IdRole", "dbo.Roles");
            DropIndex("dbo.MyUsers", new[] { "IdRole" });
            DropColumn("dbo.MyUsers", "IdRole");
            DropTable("dbo.Roles");
        }
    }
}
