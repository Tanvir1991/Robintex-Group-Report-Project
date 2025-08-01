using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class TblFdbpRealizationMaster
    {
        public long FdbpDocId { get; set; }
        public string FdbpDocNo { get; set; }
        public DateTime? FdbpDocDate { get; set; }
        public DateTime? FdbpCreated { get; set; }
        public double? FdbpTotal { get; set; }
        public double? FdbpCommission { get; set; }
    }
}
