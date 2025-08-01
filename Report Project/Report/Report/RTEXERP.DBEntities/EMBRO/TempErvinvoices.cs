using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TempErvinvoices
    {
        public int TempInvoiceId { get; set; }
        public int? TempMasterInvoiceId { get; set; }
        public int? Mlcid { get; set; }
        public string Mlcno { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public int? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? InvGrossAmount { get; set; }
        public decimal? InvNetAmount { get; set; }
        public decimal? InvCrate { get; set; }
        public decimal? InvFcamount { get; set; }
        public decimal? InvPayment { get; set; }
        public decimal? InvBalance { get; set; }
        public byte? Status { get; set; }
    }
}
