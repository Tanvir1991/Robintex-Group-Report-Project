using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmInvoiceAdjustment
    {
        public long? VoucherId { get; set; }
        public long? InvoiceId { get; set; }
        public double? AdjustedAmount { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
