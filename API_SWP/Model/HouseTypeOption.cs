using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class HouseTypeOption
    {
        public string HouseTypeId { get; set; } = null!;
        public string? HouseType { get; set; }
        public double? HouseTypePrice { get; set; }
        public string ComboDesignId { get; set; } = null!;

        public virtual ComboDesign ComboDesign { get; set; } = null!;
    }
}
