using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmInvoiceMain
    {
        public ApmInvoiceMain()
        {
            ApmInvoiceDetail = new HashSet<ApmInvoiceDetail>();
        }

        public decimal InvoiceId { get; set; }
        public string InvoiceSystemId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string Ponum { get; set; }
        public decimal SupplierId { get; set; }
        public decimal CompanyId { get; set; }
        public decimal PreparedBy { get; set; }
        public DateTime PrepareDate { get; set; }
        public string Status { get; set; }
        public decimal? ExDtyRate { get; set; }
        public int InvoiceType { get; set; }
        public decimal? CurrencyRate { get; set; }
        public decimal? AdvAdjusted { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string LcAcceptenceNo { get; set; }
        public decimal? InvoiceAmount { get; set; }

        public virtual ICollection<ApmInvoiceDetail> ApmInvoiceDetail { get; set; }
    }
}
