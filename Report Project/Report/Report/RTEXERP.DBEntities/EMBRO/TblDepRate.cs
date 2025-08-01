using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblDepRate
    {
        public int? AssetCoaid { get; set; }
        public int? Parentid { get; set; }
        public double? DepRate { get; set; }
        public int? Companyid { get; set; }
    }
}
