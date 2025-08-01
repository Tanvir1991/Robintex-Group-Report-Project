using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmPrintedCheque
    {
        public long ChqId { get; set; }
        public string ReceivingPerson { get; set; }
        public string Identification { get; set; }
        public int? Status { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
