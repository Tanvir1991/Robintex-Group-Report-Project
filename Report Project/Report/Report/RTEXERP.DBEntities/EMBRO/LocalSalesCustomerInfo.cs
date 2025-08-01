using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LocalSalesCustomerInfo
    {
        public decimal VoucherId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerDesc { get; set; }
        public string SalesTaxNumber { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
