using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class KRS_SizesViewModel
    {
        public long KRSSID { get; set; }
        public int KRSDID { get; set; }
        public int SizeID { get; set; }
        public decimal Len { get; set; }
        public decimal Wid { get; set; }

        public string Color { get; set; }
        public decimal? Quantity { get; set; }
        public double? WeightConsumption { get; set; }
        public long? FRSAttributeInstanceID { get; set; }
        public string Pantone { get; set; }
        public int? FabricTrimID { get; set; }
        public string FabricTrimName { get; set; }
        public string SizeName { get; set; }
    }
}
