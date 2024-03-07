using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Staff
    {
        public Staff()
        {
            ConstructionPriceQuotations = new HashSet<ConstructionPriceQuotation>();
            Posts = new HashSet<Post>();
        }

        public string StaffSId { get; set; } = null!;
        public string StaffSName { get; set; } = null!;
        public string StaffSEmail { get; set; } = null!;
        public string StaffPassword { get; set; } = null!;

        public virtual ICollection<ConstructionPriceQuotation> ConstructionPriceQuotations { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
