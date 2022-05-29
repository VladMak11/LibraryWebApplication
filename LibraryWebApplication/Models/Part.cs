using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class Part
    {
        public Part()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int PartsId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
