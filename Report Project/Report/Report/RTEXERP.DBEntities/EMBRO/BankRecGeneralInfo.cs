using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class BankRecGeneralInfo
    {
        public decimal VoucherId { get; set; }
        public decimal AccountId { get; set; }
        public string Description { get; set; }
        public string Billno { get; set; }
        public DateTime? Billdate { get; set; }
        public string RefNo { get; set; }
        public string BankRefNo { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Net { get; set; }
        public decimal? Dhl { get; set; }
        public decimal? Eds { get; set; }
        public decimal? Esc { get; set; }
        public decimal? Fdd { get; set; }
        public decimal? BankCharges { get; set; }
        public decimal? InTax { get; set; }
        public decimal? RecAmnt { get; set; }
        public string Comments { get; set; }
        public string CurrencyUnit { get; set; }
        public int? Vindex { get; set; }
        public long Vid { get; set; }

        public virtual BasicCoa Account { get; set; }
    }
}
