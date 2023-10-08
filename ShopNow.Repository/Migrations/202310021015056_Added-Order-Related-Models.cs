namespace ShopNow.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderRelatedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        MName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderedQuantity = c.Int(nullable: false),
                        Order_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Order_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
