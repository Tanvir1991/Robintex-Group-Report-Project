using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherReversalVoucherAssociation
    {
        public long VoucherId { get; set; }
        public long ReversalVoucherId { get; set; }
        public DateTime Rdate { get; set; }
    }
}
