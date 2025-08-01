using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblCurrencySetup
    {
        public long Id { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public byte? Status { get; set; }
        public int? CreatedBy { get; set; }
    }
}
