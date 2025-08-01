using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmPayrollDetail
    {
        public decimal InvoiceId { get; set; }
        public decimal PayrollId { get; set; }
        public decimal? InvoiceEffect { get; set; }
    }
}
