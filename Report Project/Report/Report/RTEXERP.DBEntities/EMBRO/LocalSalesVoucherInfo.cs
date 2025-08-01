using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class LocalSalesVoucherInfo
    {
        public decimal? VoucherId { get; set; }
        public decimal? AccountId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Donumber { get; set; }
        public DateTime? Dodate { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? SalesTax { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
