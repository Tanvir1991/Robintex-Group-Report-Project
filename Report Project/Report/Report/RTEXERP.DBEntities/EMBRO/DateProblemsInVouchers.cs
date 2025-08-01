using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class DateProblemsInVouchers
    {
        public decimal Id { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string PrepareDate { get; set; }
    }
}
