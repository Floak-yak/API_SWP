namespace API_SWP.Dto
{
    public class PostDto
    {
        public string PostSId { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string StaffId { get; set; } = null!;
    }
}
