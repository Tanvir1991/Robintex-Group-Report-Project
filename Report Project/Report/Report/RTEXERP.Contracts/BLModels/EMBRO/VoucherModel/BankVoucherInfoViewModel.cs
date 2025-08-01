using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO.VoucherModel
{
 public   class BankVoucherInfoViewModel
    {
        public decimal VoucherId { get; set; }
        public decimal AccountId { get; set; }
        public string InstrumentId { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public string TreasuryChallanNo { get; set; }
        public string PropertyAddress { get; set; }
        public string PayeeResident { get; set; }
        public decimal? ProfitonDebt { get; set; }
        public string BorCa { get; set; }
        public decimal? ProfessionalFees { get; set; }
        public decimal? InstrumentTypeId { get; set; }
        public string RefNo { get; set; }
        public int? Vindex { get; set; }
    }
}
