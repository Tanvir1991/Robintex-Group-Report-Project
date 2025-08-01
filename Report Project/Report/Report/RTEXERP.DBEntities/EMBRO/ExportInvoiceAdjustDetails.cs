using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.EMBRO
{
    public class ExportInvoiceAdjustDetails
    {
        public int ID { get; set; }
        [ForeignKey("ExportInvoiceAdjustMaster")]
        public int MasterID { get; set; }
        public int PackingInvoiceID { get; set; }
        public decimal Amount { get; set; }
        public long OrderID { get; set; }
        public long? StyleID { get; set; }
        public virtual ExportInvoiceAdjustMaster ExportInvoiceAdjustMaster { get; set; }

    }
}
