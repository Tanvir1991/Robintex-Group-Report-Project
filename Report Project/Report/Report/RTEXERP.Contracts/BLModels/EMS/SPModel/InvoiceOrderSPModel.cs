using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMS.SPModel
{
  public  class InvoiceOrderSPModel
    {
       public int InvoiceID { get; set; }
           public string  EPIM_INVOICENO { get; set; }
            public long POID { get; set; }
            public string PONo { get; set; }
           public string  OrderNo { get; set; }
            public long OrderID { get; set; }
        /// <summary>
        /// For OrderChek not for sp
        /// </summary>
           public int IsAdjustmentInvoice { get; set; }
        public int TotalInvoiceOrder { get; set; }
    }
}
