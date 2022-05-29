using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class OrderService
    {
        public OrderService()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderServicesId { get; set; }
        public int TypeOfServiceId { get; set; }
        public int PartsId { get; set; }

        public virtual Part Parts { get; set; } = null!;
        public virtual TypeOfService TypeOfService { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
