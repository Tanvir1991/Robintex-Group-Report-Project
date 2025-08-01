using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmPayrollBillToBill
    {
        public long? VoucherId { get; set; }
        public long? PayrollVoucherId { get; set; }
        public decimal? Payment { get; set; }
    }
}
