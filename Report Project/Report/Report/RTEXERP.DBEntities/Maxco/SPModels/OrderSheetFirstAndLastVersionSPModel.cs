using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.Maxco.SPModels
{
    public class OrderSheetFirstAndLastVersionSPModel
    {
        public int? BuyerID { get; set; }
        public string BuyerName { get; set; }
        public int? OrderID { get; set; }        
        public string OrderNo { get; set; }
        public int? FristOSVersionID { get; set; }
        public int? LastOSVersionID { get; set; }
        public DateTime? OSFirstVersionDate { get; set; }
        public DateTime? OSLastVersionDate { get; set; }
        public string StyleString { get; set; }
        public string RefString { get; set; }
        public string LCString { get; set; }
        public double? FirstAvgCostingPrice { get; set; }
        public int? FirstTotalOrderQty { get; set; }
        public decimal? FirstTotalFabricCost { get; set; }
        public double? FirstTotalFabricKG { get; set; }
        public decimal? FirstTotalInterCost { get; set; }
        public decimal? FirstTotalTrimCost { get; set; }
        public decimal? FirstTotalEmbroCost { get; set; }
        public decimal? FirstTotalPrintCost { get; set; }
        public double? FirstTotalWashingCost { get; set; }
        public double? FirstTotalAllowanceCost { get; set; }
        public double? FirstOrderFabricConsumption { get; set; }
        public double? FirstTotalSMVCost { get; set; }
        public decimal? FirstAvgNegotiatedPrice { get; set; }
        public double? FirstComissionPer { get; set; }
        public double? LastAvgCostingPrice { get; set; }
        public double? LastAvgNegotiatedPrice { get; set; }
        public int? LastTotalOrderQty { get; set; }
        public double? LastTotalFabricCost { get; set; }
        public double? LastTotalFabricKG { get; set; }
        public double? LastTotalInterCost { get; set; }
        public double? LastTotalTrimCost { get; set; }
        public double? LastTotalEmbroCost { get; set; }
        public double? LastTotalPrintCost { get; set; }
        public double? LastTotalWashingCost { get; set; }
        public double? LastTotalAllowanceCost { get; set; }
        public double? LastOrderFabricConsumption { get; set; }
        public double? LastTotalSMVCost { get; set; }
        public double? LastComissionPer { get; set; }
        public int? Diff_OrderQty { get; set; }
        public decimal? Diff_FabricQtyKG { get; set; }
        public decimal? Diff_FabricCost { get; set; }
        public decimal? Diff_TrimCost { get; set; }
        public decimal? Diff_PrintCost { get; set; }
        public decimal? Diff_AllowanceCost { get; set; }
    }
}
