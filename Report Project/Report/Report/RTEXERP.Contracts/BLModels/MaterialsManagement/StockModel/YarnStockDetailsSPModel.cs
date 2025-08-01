using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
  public  class YarnStockDetailsSPModel
    {
        public string LotNo { get; set; }
        public string YarnComposition { get; set; }
        public string YarnCount { get; set; }
        public string SupplierName { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public decimal? ReceivedQuantity { get; set; }
        public DateTime? IssueDate { get; set; }
        public decimal? IssueQuantity { get; set; }

        public string ReceivedDateST { get { return ReceivedDate.HasValue==true?ReceivedDate.Value.ToString("dd-MMM-yyyy"):""; } }
        public string IssueDateST { get { return IssueDate.HasValue == true ? IssueDate.Value.ToString("dd-MMM-yyyy") : ""; } }

        public decimal IssuedQuantityRET { get { return IssueQuantity.HasValue == true ? IssueQuantity.Value : 0; } }
        public decimal ReceivedQuantityRET { get { return ReceivedQuantity.HasValue == true ? ReceivedQuantity.Value : 0; } }
    }
}
