using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel
{
    public class PurchaseOrderStockSPModel
    {
        public int DocumentTypeID { get; set; }
        public string Company { get; set; }
        public string Business { get; set; }
        public string BuyerName { get; set; }
        public string PurchaseOrderNo { get; set; }
        public long OrderID { get; set; }
        public int BuyerID { get; set; }
        public string OrderNo { get; set; }
        public int MRPItemCode { get; set; }
        public string MRPItem { get; set; }
        public int UserSelectedUNITID { get; set; }
        public string Unit { get; set; }
        public long AttributeInstanceID { get; set; }
        public decimal OpeningQty { get; set; }
        public decimal OpeningQtyValue { get; set; }
        public decimal CurrentReceiveQty { get; set; }
        public decimal CurrentReceiveValue { get; set; }
        public decimal CurrentIssuedQty { get; set; }
        public decimal CurrentIssuedValue { get; set; }
        public decimal ClosingQuantity { get; set; }
        public decimal ClosingValue { get; set; }
        public decimal Rate { get; set; }
        public string Measurment { get; set; }
        public string ReceivedDateMSG { get; set; }
        public string IssueDateMSG { get; set; }

    }
}
