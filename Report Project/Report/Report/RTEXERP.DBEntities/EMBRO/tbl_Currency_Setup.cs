using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.EMBRO
{
    public class tbl_Currency_Setup
    {
        public long ID { get; set; }
        public string countryName { get; set; }
        public string currencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
        public int? Status { get; set; }
        public int? CreatedBy { get; set; }

    }
}
