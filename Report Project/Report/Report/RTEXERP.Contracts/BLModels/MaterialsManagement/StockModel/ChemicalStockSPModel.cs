using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class ChemicalStockSPModel
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string SupplierName { get; set; }
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public decimal OpQuantity { get; set; }
        public decimal OpValue { get; set; }
        public decimal RCVQuantity { get; set; }
        public decimal RCVValue { get; set; }
        public decimal IssueQuantity { get; set; }
        public decimal IssueValue { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal ClosingValue { get; set; }
        public decimal Rate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public string ReceivedDateST { get { return ReceivedDate.HasValue == true ? ReceivedDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public string IssueDateST { get { return IssueDate.HasValue == true ? IssueDate.Value.ToString("dd-MMM-yyyy") : ""; } }
    }
}
