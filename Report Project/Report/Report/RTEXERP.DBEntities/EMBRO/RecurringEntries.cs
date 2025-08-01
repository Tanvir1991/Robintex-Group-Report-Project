using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class RecurringEntries
    {
        public decimal Id { get; set; }
        public string Title { get; set; }
        public decimal VoucherId { get; set; }
    }
}
