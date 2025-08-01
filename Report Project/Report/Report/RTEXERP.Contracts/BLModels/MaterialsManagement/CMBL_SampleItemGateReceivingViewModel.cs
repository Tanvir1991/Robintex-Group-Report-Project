using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CMBL_SampleItemGateReceivingViewModel
    {
        public int SampleItemRecID { get; set; }
       
        public int SampleRecID { get; set; }
        public long SampleItemID { get; set; }
        public long ItemID { get; set; }
        public decimal ReceivedQuantity { get; set; }
    }
}
