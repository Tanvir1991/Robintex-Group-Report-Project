using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ViwInvoice
    {
        public decimal SupplierId { get; set; }
        public decimal InvoiceId { get; set; }
        public string Ponum { get; set; }
        public string InvoiceSystemId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Grvgross { get; set; }
        public decimal GrvsalesTax { get; set; }
        public decimal GrvexciseDuty { get; set; }
        public decimal NetAmount { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal Nedngross { get; set; }
        public decimal NednsalesTax { get; set; }
        public decimal NednexciseDuty { get; set; }
        public decimal Nedn { get; set; }
        public decimal Edngross { get; set; }
        public decimal EdnsalesTax { get; set; }
        public decimal EdnexciseDuty { get; set; }
        public decimal Edn { get; set; }
        public decimal SalesTax { get; set; }
        public decimal ExciseDuty { get; set; }
        public int? NoOfDays { get; set; }
        public DateTime PrepareDate { get; set; }
        public decimal CompanyId { get; set; }
        public int InvoiceType { get; set; }
        public string Status { get; set; }
        public decimal? AmtInDoller { get; set; }
        public decimal? CurrencyRate { get; set; }
    }
}
