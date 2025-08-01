using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class CbmChequeBook
    {
        public CbmChequeBook()
        {
            CbmCheque = new HashSet<CbmCheque>();
        }

        public decimal Id { get; set; }
        public string Prefix { get; set; }
        public string SeriesStart { get; set; }
        public string SeriesEnd { get; set; }
        public int AccountId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<CbmCheque> CbmCheque { get; set; }
    }
}
