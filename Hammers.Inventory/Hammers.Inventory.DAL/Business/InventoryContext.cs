using Hammers.Inventory.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammers.Inventory.DAL.Business
{
    public class InventoryContext : DbContext, IDisposable
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        public InventoryContext()
            : base("HammersConnection")
        {
            
        }
    }
}
