using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Quotations = new HashSet<ConstructionPriceQuotation>();
        }

        public string CustomerSId { get; set; } = null!;
        public string? CustomerEmail { get; set; }
        public string CustomerSName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<ConstructionPriceQuotation> Quotations { get; set; }
    }
}
