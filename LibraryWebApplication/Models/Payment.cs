using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int ReceiptsId { get; set; }
        public string Payer { get; set; } = null!;

        public virtual Receipt Receipts { get; set; } = null!;
    }
}
