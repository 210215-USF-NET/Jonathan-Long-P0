using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            ItemLocations = new HashSet<ItemLocation>();
            Items = new HashSet<Item>();
            Orders = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string LocationName { get; set; }

        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
