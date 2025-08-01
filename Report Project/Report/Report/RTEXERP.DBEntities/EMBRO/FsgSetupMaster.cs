using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class FsgSetupMaster
    {
        public int Fsgid { get; set; }
        public string Fsgname { get; set; }
        public string Fsgheading { get; set; }
        public int CompanyId { get; set; }
    }
}
