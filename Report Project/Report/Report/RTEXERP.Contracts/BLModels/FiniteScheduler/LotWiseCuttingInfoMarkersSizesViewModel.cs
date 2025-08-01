using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class LotWiseCuttingInfoMarkersSizesViewModel
    {
        public long MarkersSizesID { get; set; }        
        public long CuttingInfoMarkersID { get; set; }
        public string Size { get; set; }
        public int SizeSerial { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
