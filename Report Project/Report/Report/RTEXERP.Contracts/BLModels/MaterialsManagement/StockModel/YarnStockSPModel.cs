using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class YarnStockSPModel
    {
        public string Supplier { get; set; }
        public string YarnCount { get; set; }
        public string YarnComposition { get; set; }       
        public string LotNo { get; set; }
        public long AttributeInstanceID { get; set; }
        public decimal opQuantity { get; set; }
        public decimal opValue { get; set; }
        public decimal RcvQuantity { get; set; }
        public decimal RCVValue { get; set; }
        public decimal IssQuantity { get; set; }
        public decimal IssValue { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal ClosingValue { get; set; }
        public decimal Rate { get; set; }       
    }
}
