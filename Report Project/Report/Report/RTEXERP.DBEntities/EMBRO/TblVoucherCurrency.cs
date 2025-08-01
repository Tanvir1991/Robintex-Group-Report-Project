using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblVoucherCurrency
    {
        public long VoucherId { get; set; }
        public int? CurrencyId { get; set; }
        public double? Rate { get; set; }
    }
}
