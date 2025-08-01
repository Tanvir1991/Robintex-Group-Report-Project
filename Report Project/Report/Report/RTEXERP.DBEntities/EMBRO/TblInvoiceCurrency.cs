using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblInvoiceCurrency
    {
        public long InvoiceId { get; set; }
        public int? CurrencyId { get; set; }
        public double? Rate { get; set; }
    }
}
