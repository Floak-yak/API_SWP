namespace API_SWP.Dto
{
    public class RequestDto
    {
        public string RequestId { get; set; } = null!;
        public string? HouseSType { get; set; }
        public double? Size { get; set; }
        public string? Theme { get; set; }
        public int Status { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string CustomerId { get; set; } = null!;
    }
}
