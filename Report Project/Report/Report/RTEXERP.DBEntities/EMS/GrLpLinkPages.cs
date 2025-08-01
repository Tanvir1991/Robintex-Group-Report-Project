using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrLpLinkPages
    {
        public int GlpId { get; set; }
        public int SpsId { get; set; }
        public int GmlId { get; set; }
        public string GlpHome { get; set; }

        public virtual GrMlModuleLinks Gml { get; set; }
        public virtual GrPsPageSetup Sps { get; set; }
    }
}
