namespace API_SWP.Dto
{
    public class RequestDto
    {
        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Theme { get; set; } = null!;
        public DateTime? Date { get; set; }
        public int Status { get; set; }
        public string? Description { get; set; }
        public string CustomerId { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
    }
}
