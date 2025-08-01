using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherCheck
    {
        public int? UserId { get; set; }
        public int VoucherId { get; set; }
        public DateTime CheckDate { get; set; }
    }
}
