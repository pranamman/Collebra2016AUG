using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammers.Inventory.Entities
{
    public class Stock
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public long Quantity { get; set; }
        public long Rate { get; set; }
        public string Description { get; set; }
        public DateTime StockDate { get; set; }
        public virtual Product Product { get; set; }
    }
}
