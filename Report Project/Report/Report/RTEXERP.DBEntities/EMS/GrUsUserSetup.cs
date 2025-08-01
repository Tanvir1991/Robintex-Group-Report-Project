using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrUsUserSetup
    {
        public GrUsUserSetup()
        {
            ScUgUserGroup = new HashSet<ScUgUserGroup>();
        }

        public int GusId { get; set; }
        public string GusName { get; set; }
        public string GusDesc { get; set; }
        public string GusPass { get; set; }

        public virtual ICollection<ScUgUserGroup> ScUgUserGroup { get; set; }
    }
}
