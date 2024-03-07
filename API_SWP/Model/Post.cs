using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Post
    {
        public Post()
        {
            LinkImages = new HashSet<LinkImage>();
        }

        public string PostSId { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string StaffId { get; set; } = null!;

        public virtual Staff Staff { get; set; } = null!;
        public virtual ICollection<LinkImage> LinkImages { get; set; }
    }
}
