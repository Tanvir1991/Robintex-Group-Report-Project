using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherConfigurationSetup
    {
        public long Id { get; set; }
        public int? VoucherType { get; set; }
        public string Parameter { get; set; }
        public string Nature { get; set; }
        public string SelectionMode { get; set; }
        public long? AccountId { get; set; }
        public long? BusinessId { get; set; }
    }
}
