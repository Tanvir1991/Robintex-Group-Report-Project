using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class CuttingProductionReportPageMasterViewModel
    {
        public string DateDuration { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public decimal TotalSalary { get; set; } = 0;
        public int CBLProductionQty { get; set; }
        public int CBLCuttingQty { get; set; }
        public int CBLInspectionQty { get; set; }
        public int CBLPassQty { get; set; }
        public int RBLProductionQty { get; set; }
        public int RBLCuttingQty { get; set; }
        public int RBLInspectionQty { get; set; }
        public int RBLPassQty { get; set; }
        public int TotalProductionQty { get; set; }
        public int TotalCuttingQty { get; set; }
        public int TotalInspectionQty { get; set; }
        public int TotalPassQty { get; set; }
        public decimal CostPerPiece { get; set; }
        public List<CuttingProductionReportPageDetailViewModel> CuttingProductionDetail { get; set; }
    }
    public class CuttingProductionReportPageDetailViewModel
    {
        public int ChallanNo { get; set; }
        public int CompanyID { get; set; }
        public string CompanyShortName { get; set; }
        public long OrderID { get; set; }
        public string CompanyName { get; set; }
        public string LotNo { get; set; }
        public long LotID { get; set; }
        public string OrderNo { get; set; }
        public int Ins_PC { get; set; }
        public int PassQty { get; set; }
        public int CuttingQty { get; set; }
        public int DefectQty { get; set; }
        public decimal DefectPercent { get; set; }       
    }
}
