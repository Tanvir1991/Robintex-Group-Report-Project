using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Lcsmain
    {
        public int Lcnumber { get; set; }
        public long SupplierId { get; set; }
        public string LccontractNumber { get; set; }
        public DateTime Lcdate { get; set; }
        public string PaymentNature { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime ReceivingDate { get; set; }
        public string ImportedUnderSro { get; set; }
        public long Mplaccount { get; set; }
        public string SuppInvoiceNumber { get; set; }
        public string Hscode { get; set; }
        public int TransportId { get; set; }
        public string TransportNo { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
