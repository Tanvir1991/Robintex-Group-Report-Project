using RTEXERP.Contracts.BLModels.Maxco.SPModel.MerchandisingCost;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.SPModel
{

    public class OrderSheetReport
    {
        public OrderSheetReport()
        {
            OSFabricPart = new List<OSFabricPart>();
            OSTrimPart = new List<OSTrimPart>();
            MerchandisingAssessmentFabricCost = new List<MerchandisingAssessmentFabricCost>();
            MerchandisingAssessmentIndirectCost = new List<MerchandisingAssessmentIndirectCost>();
        }
        public OSFinalSummary OSFinalSummary { get; set; }
        public List<OSFabricPart> OSFabricPart { get; set; }

        public List<OSTrimPart> OSTrimPart { get; set; }
        public List<MerchandisingAssessmentFabricCost> MerchandisingAssessmentFabricCost { get; set; }
        public List<MerchandisingAssessmentIndirectCost> MerchandisingAssessmentIndirectCost { get; set; }



    }
    public class OSFinalSummary
    {
        public int? ID { get; set; }
        public int Mac_OrderQuantity { get; set; }
        public decimal Mac_FabricConsumption { get; set; }
        public decimal RequiredFabric { get; set; }
        public decimal RequiredFabric_Previous { get; set; }
        
        public decimal CostingCM { get; set; }
        public string ReviseStatus { get; set; }
        public int? OrderSheetID { get; set; }
        public string SheetNo { get; set; }
        public int? Status { get; set; }
        public string OSStatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public string VersionNo { get; set; }
        public decimal? AvgCostingPrice { get; set; }
        public decimal? AvgNegotiatedPrice { get; set; }
        public int? TotalOrderQty { get; set; }
        public decimal? TotalFabricCost { get; set; }
        public decimal? TotalInterCost { get; set; }
        public decimal? TotalTrimCost { get; set; }
        public decimal? TotalEmbroCost { get; set; }
        public decimal? TotalPrintCost { get; set; }
        public decimal? TotalWashingCost { get; set; }
        public decimal? TotalAllowanceCost { get; set; }
        public decimal? OrderFabricConsumption { get; set; }
        public decimal? TotalSMVCost { get; set; }
        public decimal? ComissionPer { get; set; }
        public string BuyerString { get; set; }
        public string OrderString { get; set; }
        public string StyleString { get; set; }
        public string RefString { get; set; }
        public string LCString { get; set; }


        public int? ID_R { get; set; }
        public string ReviseStatus_R { get; set; }
        public int? OrderSheetID_R { get; set; }
        public string SheetNo_R { get; set; }
        public int? Status_R { get; set; }
        public string OSStatus_R { get; set; }
        public DateTime? CreationDate_R { get; set; }
        public string VersionNo_R { get; set; }
        public decimal? AvgCostingPrice_R { get; set; }
        public decimal? AvgNegotiatedPrice_R { get; set; }
        public int? TotalOrderQty_R { get; set; }
        public decimal? TotalFabricCost_R { get; set; }
        public decimal? TotalInterCost_R { get; set; }
        public decimal? TotalTrimCost_R { get; set; }
        public decimal? TotalEmbroCost_R { get; set; }
        public decimal? TotalPrintCost_R { get; set; }
        public decimal? TotalWashingCost_R { get; set; }
        public decimal? TotalAllowanceCost_R { get; set; }
        public decimal? OrderFabricConsumption_R { get; set; }
        public decimal? TotalSMVCost_R { get; set; }
        public decimal? ComissionPer_R { get; set; }
        public string BuyerString_R { get; set; }
        public string OrderString_R { get; set; }
        public string StyleString_R { get; set; }
        public string RefString_R { get; set; }
        public string LCString_R { get; set; }


    }

    public class OSFabricPart
    {
        public string SheetNo { get; set; }

        public int VersionID { get; set; }
        public int MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int? FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public int? FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public double? DyeingRate { get; set; }
        public double? DyeingWastagePerFrac { get; set; }
        public string FabricComposition { get; set; }
        public int? DyeingID { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public double RequiredQty { get; set; }
        public double UnitConsumption { get; set; }
        public double SKUCost { get; set; }
        public int? SizeID { get; set; }
        public string SizeDescription { get; set; }
        public int ProcurementUnitID { get; set; }
        public string ProcurementUnit { get; set; }
        public double? WastagePercent { get; set; }
        public double WastagePercentFactor { get; set; }
        public double MAC_ConsumptionPcs { get; set; }
        public double MAC_FabricPcsAmount { get; set; }
        public decimal FabricPCToKG { get; set; }
    }

    public class OSTrimPart
    {
        public string SheetNo { get; set; }
        public int VersionID { get; set; }
        public double? MCA_CostingAmount { get; set; }
        public int MRPItemCode { get; set; }
        public string MRPItemName { get; set; }
        public long AttributeInstanceID { get; set; }
        public string ImageCode { get; set; }
        public string ImageName { get; set; }
        public string UserCode { get; set; }
        public string Measurement { get; set; }
        public string SupplierName { get; set; }
        public string VendorName { get; set; }
        public double? Consumption { get; set; }
        public double? WastageQuantity { get; set; }
        public double? WastagePercent { get; set; }
        public double? UnitCost { get; set; }
        public double? Gross { get; set; }
        public int? TrimConsumptionUnitID { get; set; }
        public int? GrossUnitID { get; set; }
        public string GrossUnit { get; set; }
        public string TrimDescription { get; set; }
        public string TrimFilterCondition { get; set; }
        public string ColorCode { get; set; }
        public int? ColorSetID { get; set; }
        public string ColorName { get; set; }
        public string TrimName { get; set; }
        public int MaterialTypeCount { get; set; }
        public double?  MaterialTypeGrossQuantity { get; set; }
        public double? MaterialTypeAmount { get; set; }
        public double? MCA_UnitCost { get; set; }


    }

}
