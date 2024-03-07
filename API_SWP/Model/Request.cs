using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Request
    {
        public Request()
        {
            Quotations = new HashSet<ConstructionPriceQuotation>();
            Themes = new HashSet<ThemeTable>();
            Types = new HashSet<TypeOfHouse>();
        }

        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Theme { get; set; } = null!;
        public DateTime? Date { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string CustomerId { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual ICollection<ConstructionPriceQuotation> Quotations { get; set; }
        public virtual ICollection<ThemeTable> Themes { get; set; }
        public virtual ICollection<TypeOfHouse> Types { get; set; }
    }
}
