using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherTempXml
    {
        public int TempXmlId { get; set; }
        public decimal? VoucherId { get; set; }
        public string VoucherXml { get; set; }
        public int? CompanyId { get; set; }
    }
}
