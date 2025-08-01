using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class OrderTotalHistoryViewModel
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int KRS_MID { get; set; }
        public int DCID { get; set; }
        public decimal OSFabricQty { get; set; }
        public decimal KRSFabricQty { get; set; }
        public decimal YarnIssuedQty { get; set; }
        public decimal GreigeFabricQty { get; set; }
        public decimal YarnReturnedQty { get; set; }
        public decimal KnittingWastageQty { get; set; }

        public decimal KnittingWastagePercent { get; set; }
        public decimal DyeingRcvQty { get; set; }
        public decimal DyeingDeliveryQty { get; set; }
        public decimal DyeingWastagQty { get; set; }
        public decimal DyeingWastagPercent { get; set; }
        public decimal CuttingQty { get; set; }
        public int CuttingPCS { get; set; }
        public int CuttingOKPC { get; set; }
        public decimal CuttingDefectKG { get; set; }
        public int CuttingDefectPC { get; set; }
        public decimal CuttingDefectPercent { get; set; }
        public int GarmentsRcvPCS { get; set; }
        public int GarmentsRejactPCS { get; set; }
        public int GarmentsDelPCS { get; set; }
        public decimal GarmentsRejectPercent { get; set; }

    }
}
