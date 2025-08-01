using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ErpPaymentTerms
    {
        public int Ptid { get; set; }
        public string Ptdescription { get; set; }
        public int CompanyId { get; set; }
        public int? NoOfDays { get; set; }
        public bool? IsDisplay { get; set; }
        public int? PaymentModeId { get; set; }
    }
}
