using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblCbmAdvancePayment
    {
        public TblCbmAdvancePayment()
        {
            TblCbmAdvancePaymentRfpRelate = new HashSet<TblCbmAdvancePaymentRfpRelate>();
        }

        public decimal Id { get; set; }
        public decimal VoucherId { get; set; }
        public decimal AccountId { get; set; }
        public decimal? Vid { get; set; }
        public decimal? Vindex { get; set; }

        public virtual ICollection<TblCbmAdvancePaymentRfpRelate> TblCbmAdvancePaymentRfpRelate { get; set; }
    }
}
