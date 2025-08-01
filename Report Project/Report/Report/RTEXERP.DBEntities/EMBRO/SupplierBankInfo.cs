using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SupplierBankInfo
    {
        public decimal? SupplierId { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }
    }
}
