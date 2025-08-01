using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ViwVoucherFiscalYear
    {
        public decimal VoucherId { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime? Vdate { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public decimal? InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? Rfpid { get; set; }
        public string Pvno { get; set; }
        public DateTime? Pvdate { get; set; }
        public decimal? Pvamount { get; set; }
    }
}
