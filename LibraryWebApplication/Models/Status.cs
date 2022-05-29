using System;
using System.Collections.Generic;

namespace LibraryWebApplication
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string NameOfStatus { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
