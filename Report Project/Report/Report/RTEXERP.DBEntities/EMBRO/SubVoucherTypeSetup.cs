using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SubVoucherTypeSetup
    {
        public int Id { get; set; }
        public int VoucherTypeId { get; set; }
        public string SubVoucherType { get; set; }
        public string Initials { get; set; }
        public int? SubVoucherTypeId { get; set; }

        public virtual VoucherTypeSetup VoucherType { get; set; }
    }
}
