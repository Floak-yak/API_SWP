using API_SWP.Model;

namespace API_SWP.Dto
{
    public class PostDto
    {
        public string PostSId { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string StaffId { get; set; } = null!;
        //public virtual ICollection<LinkImage> LinkImages { get; set; }
    }
}
