using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class TypeOfService
    {
        public TypeOfService()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int TypeOfServiceId { get; set; }
        public decimal PriceOfService { get; set; }

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
