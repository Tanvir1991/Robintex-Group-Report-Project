using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblPurchaseReport
    {
        public decimal? Amount { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string BroadGroup { get; set; }
        public string NarrowGroup { get; set; }
        public string Identity { get; set; }
        public string Des { get; set; }
    }
}
