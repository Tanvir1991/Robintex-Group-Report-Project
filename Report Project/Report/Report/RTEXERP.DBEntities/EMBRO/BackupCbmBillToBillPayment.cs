using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class BackupCbmBillToBillPayment
    {
        public long Id { get; set; }
        public long? VoucherId { get; set; }
        public long? AdjustmentVoucherId { get; set; }
        public long? InvoiceId { get; set; }
        public decimal? AdjustedAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public DateTime? EntryTime { get; set; }
    }
}
