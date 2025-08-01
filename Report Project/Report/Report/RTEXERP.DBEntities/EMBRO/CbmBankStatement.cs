using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmBankStatement
    {
        public decimal Bsid { get; set; }
        public decimal? BaccountId { get; set; }
        public DateTime? Bsdate { get; set; }
        public decimal? InstrumentTypeId { get; set; }
        public string InstrumentNo { get; set; }
        public string BankRefNo { get; set; }
        public string Particulars { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
    }
}
