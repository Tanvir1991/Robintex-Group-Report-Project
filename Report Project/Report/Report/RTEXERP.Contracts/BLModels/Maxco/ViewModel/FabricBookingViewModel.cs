using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class FabricBookingViewModel
    {
        public FabricBookingViewModel()
        {
            FabricBookingMaster = new List<FabricBookingMasterViewModel>();
        }
        public int FabricBookingID { get; set; }
        public string FabricBookingNo { get; set; }
        public int CurrentVersion { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public string DeliveryStartDateMsg { get; set; }
        public string DeliveryEndDateMsg { get; set; }
        public virtual List<FabricBookingMasterViewModel> FabricBookingMaster { get; set; }
    }
}
