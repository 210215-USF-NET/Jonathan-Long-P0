using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
