using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class ThemeTable
    {
        public ThemeTable()
        {
            Requests = new HashSet<Request>();
        }

        public string Theme { get; set; } = null!;
        public double Price { get; set; }
        public string ThemeId { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; }
    }
}
