using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmInvoiceDetailRobust
    {
        public decimal InvoiceId { get; set; }
        public decimal VoucherId { get; set; }
        public decimal? InvoiceEffect { get; set; }
    }
}
