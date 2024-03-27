using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Unit
    {
        public Unit()
        {
            Requests = new HashSet<Request>();
        }

        public string UnitId { get; set; } = null!;
        public string Unit1 { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
