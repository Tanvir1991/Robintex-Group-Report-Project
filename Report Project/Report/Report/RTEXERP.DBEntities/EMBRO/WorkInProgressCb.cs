using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class WorkInProgressCb
    {
        public int Id { get; set; }
        public DateTime? DateOfCb { get; set; }
        public double? ClosingBalance { get; set; }
        public int? AddLine { get; set; }
    }
}
