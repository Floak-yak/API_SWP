using API_SWP.Model;

namespace API_SWP.Dto
{
    public class ConstructionPriceQuotationDto
    {
        public ConstructionPriceQuotationDto()
        {
            Requests = new HashSet<RequestDto>();
        }
        public string QuotationId { get; set; } = null!;
        public string ?Status { get; set; }
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ProjectAddress { get; set; } = null!;
        public DateTime QuotationDate { get; set; }
        public string CustomerId { get; set; } = null!;
        public virtual ICollection<RequestDto> Requests { get; set; }
    }
}
