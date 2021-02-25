using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class ItemLocation
    {
        public int ItemId { get; set; }
        public int LocationId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Location Location { get; set; }
    }
}
