using API_SWP.Model;

namespace API_SWP.ViewModel
{
    public class ComboDesignModelView
    {
        public ComboDesignModelView()
        {
            HouseTypeOptions = new HashSet<HouseTypeOption>();
        }

        public string ComboId { get; set; } = null!;
        public string? TypeName { get; set; }
        public string? Describe { get; set; }
        public double? UnitPrice { get; set; }

        public virtual ICollection<HouseTypeOption> HouseTypeOptions { get; set; }
    }
}
