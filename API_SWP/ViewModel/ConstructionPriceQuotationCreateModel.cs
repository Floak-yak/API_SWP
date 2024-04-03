using API_SWP.Dto;

namespace API_SWP.ViewModel
{
    public class ConstructionPriceQuotationCreateModel
    {
        public ConstructionPriceQuotationCreateModel()
        {
            Requests = new HashSet<RequestCreateModel>();
        }
        public string CustomerName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string ProjectAddress { get; set; } = null!;
        public virtual ICollection<RequestCreateModel> Requests { get; set; }
    }
}
