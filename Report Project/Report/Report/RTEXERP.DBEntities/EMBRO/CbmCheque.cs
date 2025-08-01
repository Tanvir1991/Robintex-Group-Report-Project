using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmCheque
    {
        public decimal ChqId { get; set; }
        public string ChqNum { get; set; }
        public decimal? ChqAccountId { get; set; }
        public int? Status { get; set; }
        public decimal? SignStatus { get; set; }
        public decimal ChqBkId { get; set; }
        public decimal? ChqAmount { get; set; }
        public DateTime? ChqDate { get; set; }
        public string ChqDescription { get; set; }
        public string ChqComments { get; set; }
        public decimal? VoucherId { get; set; }
        public int? ChequeSignatoryId { get; set; }

        public virtual CbmChequeBook ChqBk { get; set; }
    }
}
