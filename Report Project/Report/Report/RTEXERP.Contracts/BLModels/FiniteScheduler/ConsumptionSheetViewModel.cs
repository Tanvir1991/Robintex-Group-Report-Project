using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class ConsumptionSheetViewModel
    {
        public ConsumptionSheetViewModel()
        {
            OrderShippingInfo = new List<OrderShippingInfoViewModel>();
            OrderColorWiseRejectionBreakdown_Report = new List<OrderColorWiseRejectionBreakdown_ReportViewModel>();
            ConsumptionSheetCM = new ConsumptionSheetCMViewModel();
        }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string BuyerName { get; set; }
        public string LastExportDate { get; set; }
        public string KRSNo { get; set; }
        public string OrderNo { get; set; }
        public string Color { get; set; }
        public int GSM { get; set; }
        public string FabricComposition { get; set; }
        public string FabricQuality { get; set; }
        public int AlgoQty { get; set; }
        public int OrderQty { get; set; }
        public int YarnInKRS { get; set; }
        public decimal CADAvg { get; set; }
        public decimal YarnInKRSPercentage { get; set; }
        public decimal BatchDelivery { get; set; }
        public decimal BatchBalance { get; set; }
        public decimal DyeingPrintQty { get; set; }
        public decimal FinishQty { get; set; }
        public decimal ProcessLoss { get; set; }
        public decimal DyeingBalance { get; set; }
        public decimal FinishQtyFromBalance { get; set; }
        public decimal DeliveryShort { get; set; }
        public int CuttingShort { get; set; }
        public decimal TotalDeliveryWillBe { get; set; }

        public decimal SewingInputPercentage { get; set; }
        public decimal SewingInputValue { get; set; }
        public int CuttingQty { get; set; }
        public decimal ActualCuttingInput { get; set; }
        public decimal PanelRejectPcs { get; set; }
        public decimal PanelRejectPercentage { get; set; }
        public decimal InspectionPcs { get; set; }
        public decimal InputBalanceWithReject { get; set; }
        public decimal CuttingProgress { get; set; }
        public decimal CuttingProgressPercentage { get; set; }
        public decimal TotalCuttingReqWithReject { get; set; }
        public decimal TotalFinishFabricMayRequired { get; set; }
        public decimal TotalBatchDeliveryRequired { get; set; }
        public int TotalFinishFabricUsed { get; set; }
        public decimal ALGOOSQty { get; set; }
        public decimal CostingConsumptionPerPiece { get; set; }
        public decimal BookingConsumptionPerPiece { get; set; }
        public decimal CuttingConsumptionPerPiece { get; set; }
        public decimal FinalConsumptionPerPiece { get; set; }

        public int KRSID { get; set; }
       

        public decimal TotalActualQty { get { return OrderShippingInfo.Count > 0 ? OrderShippingInfo.Sum(x => x.ActualODQ) : 0; } }
        public int TotalAlgoQty { get { return OrderShippingInfo.Count > 0 ? OrderShippingInfo.Sum(x => x.AlgoQty) : 0; } }
        public List<OrderShippingInfoViewModel> OrderShippingInfo { get; set; }
        public List<OrderColorWiseRejectionBreakdown_ReportViewModel> OrderColorWiseRejectionBreakdown_Report { get; set; }
        public ConsumptionSheetCMViewModel ConsumptionSheetCM{ get; set; }
    }

    public class OrderShippingInfoViewModel
    {
        public long ActualODQ { get; set; }
        public string ExportDate { get; set; }
        public string ExportWeek { get; set; }
        public int AlgoQty { get; set; }
        public decimal AdditionalInputReq { get; set; }
        public decimal BatchDeliveryQty { get; set; }
        public decimal KnittingDeliveryQty { get; set; }
        public decimal KnittingDeliveryBalance { get; set; }
        public decimal ReqFinishFabric { get; set; }
        public decimal DyeingDeliveryQty { get; set; }
        public decimal DyeingDeliveryBalance { get; set; }
    }
}
