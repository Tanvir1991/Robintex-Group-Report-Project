using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmCurrency
    {
        public CbmCurrency()
        {
            CbmBankAccountSetup = new HashSet<CbmBankAccountSetup>();
        }

        public int CurId { get; set; }
        public string CurName { get; set; }
        public string CurAbbreviation { get; set; }
        public string CurSign { get; set; }

        public virtual ICollection<CbmBankAccountSetup> CbmBankAccountSetup { get; set; }
    }
}
