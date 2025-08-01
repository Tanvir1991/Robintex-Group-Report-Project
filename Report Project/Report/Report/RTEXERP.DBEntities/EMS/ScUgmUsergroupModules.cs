using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class ScUgmUsergroupModules
    {
        public int SugmId { get; set; }
        public int SgsId { get; set; }
        public int GmsId { get; set; }
        public byte PtId { get; set; }

        public virtual GrMsModuleSetup Gms { get; set; }
        public virtual ScPtPermissionTypes Pt { get; set; }
        public virtual ScGsGroupSetup Sgs { get; set; }
    }
}
