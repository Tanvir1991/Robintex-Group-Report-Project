using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblCbmAdvancePaymentRfpRelate
    {
        public int Id { get; set; }
        public decimal AdvancePaymentId { get; set; }
        public decimal InvoiceId { get; set; }
        public int Rfpid { get; set; }
        public decimal AmountDeducted { get; set; }
        public DateTime? EntryTime { get; set; }

        public virtual TblCbmAdvancePayment AdvancePayment { get; set; }
    }
}
