using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblPeriod
    {
        public long PeriodId { get; set; }
        public string PeriodName { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public int? PeriodYear { get; set; }
        public DateTime? PeriodCreated { get; set; }
        public short? PeriodStatus { get; set; }
    }
}
