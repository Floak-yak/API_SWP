namespace API_SWP.Dto
{
    public class RequestDto
    {
        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Unit { get; set; } = null!;
        public string QuotationId { get; set; } = null!;
    }
}
