using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class PostImg
    {
        public string LinkId { get; set; } = null!;
        public string? Link { get; set; }
        public string PostId { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
    }
}
