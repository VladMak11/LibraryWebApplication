using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class Order
    {
        public Order()
        {
            Receipts = new HashSet<Receipt>();
        }

        public int OrderId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfCompletion { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public int OrderServicesId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual OrderService OrderServices { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
