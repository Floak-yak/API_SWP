namespace API_SWP.Dto
{
    public class HouseTypeOptionDto
    {
        public string HouseTypeId { get; set; } = null!;
        public string? HouseType { get; set; }
        public double? HouseTypePrice { get; set; }
        public string ComboDesignId { get; set; } = null!;
    }
}
