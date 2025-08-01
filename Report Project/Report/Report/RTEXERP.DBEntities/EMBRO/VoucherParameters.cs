using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherParameters
    {
        public int VoucherType { get; set; }
        public string EntryType { get; set; }
        public int AccountId { get; set; }
        public string Treatment { get; set; }
        public int? BusinessId { get; set; }

        public virtual VoucherTypeSetup VoucherTypeNavigation { get; set; }
    }
}
