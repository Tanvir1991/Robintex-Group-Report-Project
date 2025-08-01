using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
  public  class GSPInvoiceDataModel
    {
        public int  Sl { get; set; }
        public int? InvoiceID { get; set; }
        public long? OrderID { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Status { get; set; }
        public  int InsertedData { get; set; }
        public long? StyleID { get; set; }
    }
     
}
