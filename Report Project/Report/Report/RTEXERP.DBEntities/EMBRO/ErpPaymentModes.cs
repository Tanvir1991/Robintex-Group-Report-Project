using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ErpPaymentModes
    {
        public int Pmid { get; set; }
        public string Pmdescription { get; set; }
        public int CompanyId { get; set; }
    }
}
