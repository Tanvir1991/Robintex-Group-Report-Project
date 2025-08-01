using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class ScUgUserGroup
    {
        public int SugId { get; set; }
        public int GusId { get; set; }
        public int SgsId { get; set; }

        public virtual GrUsUserSetup Gus { get; set; }
        public virtual ScGsGroupSetup Sgs { get; set; }
    }
}
