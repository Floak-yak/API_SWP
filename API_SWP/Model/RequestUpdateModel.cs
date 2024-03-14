namespace API_SWP.Model
{
    public class RequestUpdateModel
    {
        public string HouseSType { get; set; } = null!;
        public double? Size { get; set; }
        public string Theme { get; set; } = null!;
        public int Status { get; set; }
        public string? Description { get; set; }
    }
}
