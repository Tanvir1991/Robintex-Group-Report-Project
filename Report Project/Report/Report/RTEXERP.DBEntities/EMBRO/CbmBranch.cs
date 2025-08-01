using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmBranch
    {
        public CbmBranch()
        {
            CbmBankAccountSetup = new HashSet<CbmBankAccountSetup>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public int? BankId { get; set; }

        public virtual CbmBank Bank { get; set; }
        public virtual ICollection<CbmBankAccountSetup> CbmBankAccountSetup { get; set; }
    }
}
