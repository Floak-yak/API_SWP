using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Request
    {
        public Request()
        {
            Types = new HashSet<TypeOfHouse>();
            Units = new HashSet<Unit>();
        }

        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Unit { get; set; } = null!;
        public string QuotationId { get; set; } = null!;

        public virtual ConstructionPriceQuotation Quotation { get; set; } = null!;

        public virtual ICollection<TypeOfHouse> Types { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
