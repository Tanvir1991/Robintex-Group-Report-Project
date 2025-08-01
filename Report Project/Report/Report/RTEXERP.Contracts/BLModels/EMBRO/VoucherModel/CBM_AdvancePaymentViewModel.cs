using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
   public class CBM_AdvancePaymentViewModel
    {
        public decimal Id { get; set; }
        public decimal VoucherId { get; set; }
        public decimal AccountId { get; set; }
        public decimal? Vid { get; set; }
        public decimal? Vindex { get; set; }
    }
}
