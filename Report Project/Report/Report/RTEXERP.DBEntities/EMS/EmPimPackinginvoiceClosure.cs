using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class EmPimPackinginvoiceClosure
    {
        public long InvoiceId { get; set; }
        public DateTime? ClosureDate { get; set; }
        public string ClosureBy { get; set; }
    }
}
