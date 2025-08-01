using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblCurrencyDetail
    {
        public decimal? RateInPakRs { get; set; }
        public DateTime? Date { get; set; }
        public long? EnteredBy { get; set; }
        public long? CurId { get; set; }
    }
}
