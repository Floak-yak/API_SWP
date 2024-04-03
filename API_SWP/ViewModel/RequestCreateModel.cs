namespace API_SWP.ViewModel
{
    public class RequestCreateModel
    {
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Unit { get; set; } = null!;
        public double? UnitPrice { get; set; }
        public string? Describe { get; set; }
    }
}
