using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ModeOfPayment
    {
        public int ModeId { get; set; }
        public string Description { get; set; }
        public int NoOfDays { get; set; }
    }
}
