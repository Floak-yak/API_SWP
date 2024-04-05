namespace API_SWP.ViewModel
{
    public class RequestCreateModel
    {
        public string HouseSType { get; set; } = null!;
        public double? AreaSquareValue { get; set; }
        public string Name { get; set; } = null!;
        public double? UnitPrice { get; set; }
        public string? Describe { get; set; }
        public double? HouseTypePrice { get; set; }
    }
}
