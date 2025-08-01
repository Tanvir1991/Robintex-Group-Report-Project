using RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
  public class DD_PO_PurchaseOrderDetailsInfoSPModel
    {
 
        public long PurchaseOrderID { get; set; }
        public int OrderID { get; set; }
        public int ModelID { get; set; }
        public int MRPItemCode { get; set; }
        public string MRPItemName { get; set; }
        public long AttributeInstanceID { get; set; }
        public string ReqNo { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int NetQuantity { get; set; }
        public string DeliveryDate { get; set; }
        public int MRRID { get; set; }
        public int OrderedQty { get; set; }
        public decimal OrderedQtyAmount { get; set; }
        public int BalanceQty { get; set; }
        public decimal ConversionToSKU { get; set; }
        public int MinPurchaseQty { get; set; }
        public string DeliveryLocation { get; set; }
        public string StyleName { get; set; }

        public decimal UnitPrice { get; set; }
public string        CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal CurrencyRate { get; set; }
       public MRPAttributes MRPAttributes { get; set; }
    }
}
