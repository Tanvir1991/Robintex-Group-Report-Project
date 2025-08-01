using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class LotWiseCuttingStatusViewModel
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string Color { get; set; }
        public string Fabric { get; set; }
        public string FabricQuality { get; set; }
        public int Dia { get; set; }
        public int GSM { get; set; }
        public int TotalQty { get; set; }
        public int OrderQtyKg { get; set; }
        public int TotalPetitQty { get; set; }
        public decimal CuttingTargetPercentage { get; set; }
        public decimal SewingInputPercentage { get; set; }
        public decimal CuttingTargetValue { get; set; }
        public decimal SewingInputValue { get; set; }
        public int TotalCuttingQty { get; set; }
        public decimal CuttingCons { get; set; }
        public decimal CADAvg { get; set; }
        public decimal CostedCons { get; set; }
        public string CostedConsUnit { get; set; }
        public decimal PanelRejectPcs { get; set; }
        public decimal PanelRejectPercentage { get; set; }
        public decimal InspectionPcs { get; set; }
        public int CuttingBalanceToSweingInput { get; set; }
        public decimal UsedFabric { get; set; }
        public decimal InputAchievedBeforeInspection { get; set; }
        public int TotalFinishFabricUsed { get; set; }
        public decimal ALGOOSQty { get; set; }
        public decimal TotalFinishFabricMayReq { get; set; }

        public string ReportDateFrom { get; set; }
        public string ReportDateTo { get; set; }

        public int? MarkerCuttingPlanMaster_ExcelID { get; set; }
        public List<LotWiseCuttingInfoViewModel> LotWiseCuttingInfo { get; set; }        
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> ColorList { get; set; }
        
    }
}
