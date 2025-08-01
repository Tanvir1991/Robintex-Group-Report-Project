using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmBank
    {
        public CbmBank()
        {
            CbmBankFacility = new HashSet<CbmBankFacility>();
            CbmBranch = new HashSet<CbmBranch>();
        }

        public int BankId { get; set; }
        public string BankName { get; set; }
        public int? BankStatus { get; set; }
        public decimal? CompanyId { get; set; }
        public string Abbr { get; set; }

        public virtual BasicCoa Company { get; set; }
        public virtual ICollection<CbmBankFacility> CbmBankFacility { get; set; }
        public virtual ICollection<CbmBranch> CbmBranch { get; set; }
    }
}
