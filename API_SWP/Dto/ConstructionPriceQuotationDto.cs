namespace API_SWP.Dto
{
    public class ConstructionPriceQuotationDto
    {
        public string QuotationId { get; set; } = null!;
        public string? Product { get; set; }
        public string? HouseSType { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public string? Payment { get; set; }
        public string? Advise { get; set; }
        public string? CustomerComment { get; set; }
        public string StaffId { get; set; } = null!;
        public string RequestId { get; set; } = null!;
    }
}
