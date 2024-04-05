using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Request
    {
        public Request()
        {
            Combos = new HashSet<ComboDesign>();
            Types = new HashSet<TypeOfHouse>();
            Units = new HashSet<Unit>();
        }

        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? AreaSquareValue { get; set; }
        public string Name { get; set; } = null!;
        public string QuotationId { get; set; } = null!;
        public double? UnitPrice { get; set; }
        public string? Describe { get; set; }
        public double? HouseTypePrice { get; set; }

        public virtual ConstructionPriceQuotation Quotation { get; set; } = null!;

        public virtual ICollection<ComboDesign> Combos { get; set; }
        public virtual ICollection<TypeOfHouse> Types { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
