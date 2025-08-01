using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class FabricStockReportSPModel
    {
        public int Sl { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public int OrderID { get; set; }
        public string OrderNo { get; set; }
        public int PantoneID { get; set; }
        public string PantoneNo { get; set; }
        public string Composition { get; set; }
        public string FabricType { get; set; }
        public string GSM { get; set; }
        public string Dia { get; set; }
        public string Unit { get; set; }
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public decimal LotQuantity { get; set; }
        public long RollID { get; set; }
        public string RollNo { get; set; }
        public decimal RollQuantity { get; set; }
        public decimal FinishFabricQuantity { get; set; }
        public decimal FinishFabricRate { get; set; }
        public decimal FinishFabricValue { get; set; }
        public decimal IssueQuantity { get; set; }
        public decimal IssueValue { get; set; }
        public decimal ClosingQuantity { get; set; }
        public long AttributeInstanceID { get; set; }
        public decimal Value { get; set; }
        public decimal Rate { get; set; }

        public DateTime DateTo { get; set; }
        public string LotCreationDateMsg { get; set; }
        public string InspectionDateMsg { get; set; }
        public string IssueDateMsg { get; set; }
        

    }
}
