namespace Hammers.Inventory.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationmodififd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StockProducts", "Stock_StockId", "dbo.Stocks");
            DropForeignKey("dbo.StockProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.StockProducts", new[] { "Stock_StockId" });
            DropIndex("dbo.StockProducts", new[] { "Product_ProductId" });
            CreateIndex("dbo.Stocks", "ProductId");
            AddForeignKey("dbo.Stocks", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropTable("dbo.StockProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StockProducts",
                c => new
                    {
                        Stock_StockId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Stock_StockId, t.Product_ProductId });
            
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            CreateIndex("dbo.StockProducts", "Product_ProductId");
            CreateIndex("dbo.StockProducts", "Stock_StockId");
            AddForeignKey("dbo.StockProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.StockProducts", "Stock_StockId", "dbo.Stocks", "StockId", cascadeDelete: true);
        }
    }
}
