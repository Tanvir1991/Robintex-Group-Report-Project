using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Esvstatus
    {
        public long Esvid { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal Remaining { get; set; }
    }
}
