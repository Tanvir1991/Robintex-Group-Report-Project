using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class KnittingProductionReportDataPageModel
    {
        public KnittingProductionReportDataPageModel()
        {
            ReportDataList = new List<GetKnittingProductionSPModel>();
        }
        public string CompanyName { get; set; }
        public string DateDuration { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public double Salary { get; set; }
        public List<GetKnittingProductionSPModel> ReportDataList { get; set; }
    }
    public class GetKnittingProductionSPModel
    {

        public DateTime TransactionDate { get; set; }
        public string Companyname { get; set; }
        public long CompanyID { get; set; }
        public int MachineNo { get; set; }
        public int MachineDIA { get; set; }
        public string BRAND { get; set; }
        public int MachineGuage { get; set; }
        public string FabricType { get; set; }
        public string FabricQuality { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public double Width { get; set; }
        public string BuyerName { get; set; }
        public string OrderNo { get; set; }
        public long OrderID { get; set; }
        public double ShiftA { get; set; }
        public double ShiftB { get; set; }
        public double ShiftC { get; set; }
        public double TotalQuantity { get; set; }
        public double QuantityValue { get; set; }

    }
}
