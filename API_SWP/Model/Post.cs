using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class Post
    {
        public Post()
        {
            PostDetails = new HashSet<PostDetail>();
            PostImgs = new HashSet<PostImg>();
        }

        public string PostSId { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string StaffId { get; set; } = null!;
        public string? ImgLink { get; set; }
        public string Title { get; set; } = null!;

        public virtual Staff Staff { get; set; } = null!;
        public virtual ICollection<PostDetail> PostDetails { get; set; }
        public virtual ICollection<PostImg> PostImgs { get; set; }
    }
}
