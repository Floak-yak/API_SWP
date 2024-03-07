using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class ConstructionPriceQuotation
    {
        public ConstructionPriceQuotation()
        {
            Requests = new HashSet<Request>();
        }

        public string QuotationId { get; set; } = null!;
        public string? Product { get; set; }
        public string? HouseSType { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public string? Payment { get; set; }
        public string? Advise { get; set; }
        public string? CustomerComment { get; set; }
        public string StaffId { get; set; } = null!;
        public string RequestId { get; set; } = null!;

        public virtual Staff Staff { get; set; } = null!;
        public virtual ConstructionReceived? ConstructionReceived { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
