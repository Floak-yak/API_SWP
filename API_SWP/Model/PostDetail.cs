using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class PostDetail
    {
        public string PostDetailId { get; set; } = null!;
        public string? Details { get; set; }
        public string PostId { get; set; } = null!;

        public virtual Post Post { get; set; } = null!;
    }
}
