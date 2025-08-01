using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class EsvagentInfo
    {
        public decimal VoucherId { get; set; }
        public int CommissionAgentId { get; set; }
        public float? CommissionPercent { get; set; }
        public float? TamountinRs { get; set; }
        public string Currency { get; set; }
        public decimal? ConvRate { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
