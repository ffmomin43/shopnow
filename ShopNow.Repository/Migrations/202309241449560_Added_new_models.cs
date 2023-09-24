namespace ShopNow.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_new_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductBullets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LineText = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        AltText = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "ProductTitle", c => c.String());
            AddColumn("dbo.Products", "RatingNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductDescription", c => c.String());
            AddColumn("dbo.Products", "ActualPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "SalePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "AvailableQuantity", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Products", "Expiry");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Expiry", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String());
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductBullets", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropIndex("dbo.ProductBullets", new[] { "Product_Id" });
            DropColumn("dbo.Products", "AvailableQuantity");
            DropColumn("dbo.Products", "SalePrice");
            DropColumn("dbo.Products", "ActualPrice");
            DropColumn("dbo.Products", "ProductDescription");
            DropColumn("dbo.Products", "RatingNumber");
            DropColumn("dbo.Products", "ProductTitle");
            DropTable("dbo.ProductImages");
            DropTable("dbo.ProductBullets");
            DropTable("dbo.Categories");
        }
    }
}
