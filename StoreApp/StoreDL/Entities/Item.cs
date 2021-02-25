using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Item
    {
        public Item()
        {
            ItemLocations = new HashSet<ItemLocation>();
        }

        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
    }
}
