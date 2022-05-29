using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class Receipt
    {
        public Receipt()
        {
            Payments = new HashSet<Payment>();
        }

        public int ReceiptsId { get; set; }
        public DateTime Date { get; set; }
        public decimal PaymentAmount { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
