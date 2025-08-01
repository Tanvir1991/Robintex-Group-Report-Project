using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class FabricBookingVersionViewModel
    {
        public int FabricBookingID { get; set; }
        public string FabricBookingNo { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int BookingMasterID { get; set; }
        public int Version { get; set; }
        public string DeliveryStartDateMsg { get; set; }
        public string DeliveryEndDateMsg { get; set; }
        public bool IsActive { get; set; }
        public string Reference { get; set; }
        public string CreatedDateMsg { get; set; }
    }
}
