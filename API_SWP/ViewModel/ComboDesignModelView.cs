using API_SWP.Dto;
using API_SWP.Model;

namespace API_SWP.ViewModel
{
    public class ComboDesignModelView
    {
        public ComboDesignModelView()
        {
            HouseTypeOptions = new HashSet<HouseTypeOptionDto>();
        }

        public string ComboId { get; set; } = null!;
        public string? TypeName { get; set; }
        public string? Describe { get; set; }
        public double? UnitPrice { get; set; }

        public virtual ICollection<HouseTypeOptionDto> HouseTypeOptions { get; set; }
    }
}
