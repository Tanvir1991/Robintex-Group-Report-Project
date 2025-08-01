using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmInvoiceDetail
    {
        public decimal InvoiceId { get; set; }
        public decimal VoucherId { get; set; }
        public decimal? InvoiceEffect { get; set; }

        public virtual ApmInvoiceMain Invoice { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
