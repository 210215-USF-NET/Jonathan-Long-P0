using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int? CustId { get; set; }
        public int? LocationId { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
