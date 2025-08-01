using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ClosingDates
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int FiscalYear { get; set; }
        public int CompId { get; set; }
        public int TypeId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ClosingTypes Type { get; set; }
    }
}
