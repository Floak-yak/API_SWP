namespace API_SWP.Model
{
    public class ConstructionPriceQuotationUpdateModel
    {
        public string? Product { get; set; }
        public string? HouseSType { get; set; }
        public int Status { get; set; }
        public double Price { get; set; }
        public string? Payment { get; set; }
        public string? Advise { get; set; }
        public string? CustomerComment { get; set; }
    }
}
