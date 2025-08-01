using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class GspMaster
    {
        public int GspmasterId { get; set; }
        public string GspmasterNo { get; set; }
        public DateTime GspmasterDate { get; set; }
        public decimal ChequeId { get; set; }
    }
}
