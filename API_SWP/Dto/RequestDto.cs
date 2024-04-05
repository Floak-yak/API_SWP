namespace API_SWP.Dto
{
    public class RequestDto
    {
        public string RequestId { get; set; } = null!;
        public string HouseSType { get; set; } = null!;
        public double? AreaSquareValue { get; set; }
        public string Name { get; set; } = null!;
        public string QuotationId { get; set; } = null!;
        public double? UnitPrice { get; set; }
        public string? Describe { get; set; }
        public double? HouseTypePrice { get; set; }
    }
}
