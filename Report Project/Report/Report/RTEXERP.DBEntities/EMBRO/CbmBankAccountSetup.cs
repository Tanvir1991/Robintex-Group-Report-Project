using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmBankAccountSetup
    {
        public decimal BaccountId { get; set; }
        public string BaccountName { get; set; }
        public decimal? TypeId { get; set; }
        public int? CurrId { get; set; }
        public int? BranchId { get; set; }
        public decimal? Limit { get; set; }
        public string Lremarks { get; set; }

        public virtual BasicCoa Baccount { get; set; }
        public virtual CbmBranch Branch { get; set; }
        public virtual CbmCurrency Curr { get; set; }
        public virtual BasicCoa Type { get; set; }
    }
}
