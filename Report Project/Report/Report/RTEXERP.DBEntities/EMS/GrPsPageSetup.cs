using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrPsPageSetup
    {
        public GrPsPageSetup()
        {
            GrLpLinkPages = new HashSet<GrLpLinkPages>();
        }

        public int SpsId { get; set; }
        public string SpsName { get; set; }
        public string SpsDesc { get; set; }
        public string SpsPath { get; set; }
        public bool SpsIsactive { get; set; }

        public virtual ICollection<GrLpLinkPages> GrLpLinkPages { get; set; }
    }
}
