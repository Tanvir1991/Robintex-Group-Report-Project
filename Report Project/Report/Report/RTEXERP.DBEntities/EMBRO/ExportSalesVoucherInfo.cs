using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ExportSalesVoucherInfo
    {
        public decimal VoucherId { get; set; }
        public decimal? InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetAmount { get; set; }
        public string Currency { get; set; }
        public decimal? ConvRate { get; set; }
        public string Destination { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? AccountId { get; set; }
        public int? Vindex { get; set; }
        public int? BankId { get; set; }
        public string FormNo { get; set; }
        public int Id { get; set; }
        public long? CavoucherId { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
