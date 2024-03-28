using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class UrlPath
    {
        public string UrlId { get; set; } = null!;
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Imgurl { get; set; }
        public string? Description { get; set; }
    }
}
