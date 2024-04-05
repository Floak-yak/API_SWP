using System;
using System.Collections.Generic;

namespace API_SWP.Model
{
    public partial class HouseTypeOption
    {
        public string houseTypeId { get; set; } = null!;
        public string? houseType { get; set; }
        public double? houseTypePrice { get; set; }
        public string comboDesignId { get; set; } = null!;

        public virtual ComboDesign ComboDesign { get; set; } = null!;
    }
}
