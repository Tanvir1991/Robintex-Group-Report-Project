using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ViwAgeingDetailReport
    {
        public string Status { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int? ParentId { get; set; }
        public string ControlAccount { get; set; }
        public string Creditors { get; set; }
        public int NofDays { get; set; }
    }
}
