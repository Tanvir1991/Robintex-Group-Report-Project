using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ClosingTypes
    {
        public ClosingTypes()
        {
            ClosingDates = new HashSet<ClosingDates>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<ClosingDates> ClosingDates { get; set; }
    }
}
