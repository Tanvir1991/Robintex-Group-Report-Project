using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmRfpDetail
    {
        public decimal Rfpid { get; set; }
        public decimal InvoiceId { get; set; }

        public virtual CbmRfp Rfp { get; set; }
    }
}
