namespace API_SWP.Dto
{
    public class ConstructionPriceQuotationDto
    {
        public string QuotationId { get; set; } = null!;
        public int Status { get; set; }
        public string StaffId { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ProjectAddress { get; set; } = null!;
        public DateTime QuotationDate { get; set; }
        public string CustomerId { get; set; } = null!;
    }
}
