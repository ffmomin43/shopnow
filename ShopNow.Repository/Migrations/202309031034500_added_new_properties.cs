namespace ShopNow.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "Expiry", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Expiry");
            DropColumn("dbo.Products", "Name");
        }
    }
}
