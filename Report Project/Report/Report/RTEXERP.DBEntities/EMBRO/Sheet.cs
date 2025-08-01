using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Sheet
    {
        public string GrvNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        public double? PoNo { get; set; }
        public double? OldIdOfCoa { get; set; }
        public double? NewIdOfCoa { get; set; }
        public string ItemName { get; set; }
        public double? AccountHead { get; set; }
        public string F8 { get; set; }
        public string LedgerPageNo { get; set; }
    }
}
