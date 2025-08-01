using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class GeneralParameters
    {
        public int ParamId { get; set; }
        public string GeneralDecription { get; set; }
        public long? AccountId { get; set; }
        public int? CompanyId { get; set; }
        public string OtherDesc { get; set; }
    }
}
