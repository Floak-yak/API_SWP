using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class TypeOfHouse
    {
        public TypeOfHouse()
        {
            Requests = new HashSet<Request>();
        }

        public string TypeId { get; set; } = null!;
        public string TypeName { get; set; } = null!;
        public double? PriceEstimateCaculateType { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
