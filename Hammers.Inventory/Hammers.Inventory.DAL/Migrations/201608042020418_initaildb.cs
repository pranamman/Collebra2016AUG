namespace Hammers.Inventory.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initaildb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Long(nullable: false),
                        Rate = c.Long(nullable: false),
                        Description = c.String(),
                        StockDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StockId);
            
            CreateTable(
                "dbo.StockProducts",
                c => new
                    {
                        Stock_StockId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stock_StockId, t.Product_ProductId })
                .ForeignKey("dbo.Stocks", t => t.Stock_StockId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Stock_StockId)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.StockProducts", "Stock_StockId", "dbo.Stocks");
            DropIndex("dbo.StockProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.StockProducts", new[] { "Stock_StockId" });
            DropTable("dbo.StockProducts");
            DropTable("dbo.Stocks");
            DropTable("dbo.Products");
        }
    }
}
