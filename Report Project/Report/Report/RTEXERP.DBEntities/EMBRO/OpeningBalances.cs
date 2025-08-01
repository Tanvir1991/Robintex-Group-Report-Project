using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class OpeningBalances
    {
        public decimal AccountId { get; set; }
        public decimal OpeningBalance { get; set; }
        public int? CostCenterId { get; set; }
        public int? ActivityId { get; set; }
        public int? LocationId { get; set; }
        public int FiscalYear { get; set; }
        public DateTime Rdate { get; set; }
        public long Vid { get; set; }
    }
}
