using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class ConstructionReceived
    {
        public string ConstructionReceivedId { get; set; } = null!;
        public string? HouseSType { get; set; }
        public DateTime? Date { get; set; }
        public double? Price { get; set; }
        public int Status { get; set; }
        public string QuotationId { get; set; } = null!;

        public virtual ConstructionPriceQuotation Quotation { get; set; } = null!;
    }
}
