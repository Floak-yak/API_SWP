using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class ConstructionPriceQuotation
    {
        public ConstructionPriceQuotation()
        {
            Requests = new HashSet<Request>();
            Customers = new HashSet<Customer>();
        }

        public string QuotationId { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string StaffId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ProjectAddress { get; set; } = null!;
        public DateTime QuotationDate { get; set; }
        public string CustomerId { get; set; } = null!;

        public virtual Staff Staff { get; set; } = null!;
        public virtual ConstructionReceived? ConstructionReceived { get; set; }
        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
