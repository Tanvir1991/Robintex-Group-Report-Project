using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class ScUgmUsergroupLinks
    {
        public int SugmId { get; set; }
        public int SgsId { get; set; }
        public int GmlId { get; set; }
        public byte PtId { get; set; }

        public virtual GrMlModuleLinks Gml { get; set; }
        public virtual ScGsGroupSetup Sgs { get; set; }
    }
}
