using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class GspDetails
    {
        public int GspdetailsId { get; set; }
        public int GspmasterId { get; set; }
        public int InvoiceId { get; set; }
        public string Gspno { get; set; }
        public DateTime Gspdate { get; set; }
    }
}
