using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class FabricBookingSizeDetailViewModel
    {
        public int BookingSizeID { get; set; }
        public int KRSDID { get; set; }
        public int BookingDetailID { get; set; }
        public int FabricTrimID { get; set; }
        public int SizeID { get; set; }
        public string SizeName { get; set; }
        public decimal Len { get; set; }
        public decimal Wid { get; set; }
        public string PantoneNo { get; set; }
        public decimal? Quantity { get; set; }       
        public double? WeightConsumption { get; set; }
        public string FabricTrimName { get; set; }
    }
}
