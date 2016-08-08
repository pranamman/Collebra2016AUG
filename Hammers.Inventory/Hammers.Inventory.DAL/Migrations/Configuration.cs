namespace Hammers.Inventory.DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hammers.Inventory.DAL.Business.InventoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hammers.Inventory.DAL.Business.InventoryContext context)
        {

            List<Product> InititalProducts = new List<Product>();
            InititalProducts.Add(new Entities.Product() { Name = "Test Hammer 1", Code = "HAM001", Description = "First Hammer in the Inventory" });
            InititalProducts.Add(new Entities.Product() { Name = "Test Hammer 2", Code = "HAM002", Description = "Second Hammer in the Inventory" });
            InititalProducts.Add(new Entities.Product() { Name = "Test Hammer 3", Code = "HAM003", Description = "Third Hammer in the Inventory" });

            foreach (Product p in InititalProducts)
            {
                context.Products.Add(p);
            }

            foreach (Product p in context.Products)
            {
                p.Stocks.Add(new Stock() { ProductId = p.ProductId, Quantity = 100, Rate = 50, Description = "Opening Stock", StockDate = DateTime.Now });
            }
            context.SaveChanges();
        }
    }
}
