using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class BankAccountSetup
    {
        public decimal AccountId { get; set; }
        public string AccountName { get; set; }
        public int? AccountTypeId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
    }
}
