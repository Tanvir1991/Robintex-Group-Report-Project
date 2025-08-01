using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ViwLedger
    {
        public decimal Voucherid { get; set; }
        public string Vouchernumber { get; set; }
        public DateTime? Vdate { get; set; }
        public string Description { get; set; }
        public int? Vindex { get; set; }
        public decimal Amount { get; set; }
    }
}
