using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class LotWiseCuttingStatusSearchResultViewModel
    {
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime CuttingReportingDate { get; set; }
        public string CuttingReportingDateMsg { get { return CuttingReportingDate.ToString("dd-MMM-yyyy"); } }
        public string PantoneNo { get; set; }
        public int TotalQty { get; set; }
        public decimal UsedFabric { get; set; }
        public int TotalActualCutQty { get; set; }
        public int OrderQtyKG { get; set; }
        public decimal UsedFabricPercent { get; set; }
        public int? CuttingPlanMasterID { get; set; }
    }
}
