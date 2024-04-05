using API_SWP.Dto;
using API_SWP.Model;

namespace API_SWP.ViewModel
{
    public class ComboDesignModelView
    {
        public ComboDesignModelView()
        {
            HouseTypeOptions = new HashSet<HouseTypeOptionModelView>();
        }

        public string ComboId { get; set; } = null!;
        public string? TypeName { get; set; }
        public string? Describe { get; set; }
        public double? unit_price { get; set; }

        public virtual ICollection<HouseTypeOptionModelView> HouseTypeOptions { get; set; }
    }
}
