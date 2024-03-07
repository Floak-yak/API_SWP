namespace API_SWP.Dto
{
    public class ConstructionReceivedDto
    {
        public string ConstructionReceivedId { get; set; } = null!;
        public string? HouseSType { get; set; }
        public DateTime? Date { get; set; }
        public double? Price { get; set; }
        public int Status { get; set; }
        public string QuotationId { get; set; } = null!;
    }
}
