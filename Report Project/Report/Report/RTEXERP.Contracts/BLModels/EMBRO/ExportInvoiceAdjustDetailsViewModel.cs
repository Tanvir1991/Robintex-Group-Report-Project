using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class ExportInvoiceAdjustDetailsViewModel
    {
        public int ID { get; set; }
        public int MasterID { get; set; }
        public int PackingInvoiceID { get; set; }
        public decimal Amount { get; set; }
        public long OrderID { get; set; }
        public long? StyleID { get; set; }

    }
}
