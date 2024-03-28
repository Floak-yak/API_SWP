using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class ComboDesign
    {
        public ComboDesign()
        {
            Requests = new HashSet<Request>();
        }

        public string ComboId { get; set; } = null!;
        public string? TypeName { get; set; }
        public string? Describe { get; set; }
        public string? Unit { get; set; }
        public double? UnitPrice { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
