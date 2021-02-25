using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
