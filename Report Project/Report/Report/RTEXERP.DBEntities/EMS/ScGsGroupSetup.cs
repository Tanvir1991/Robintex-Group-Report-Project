using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class ScGsGroupSetup
    {
        public ScGsGroupSetup()
        {
            ScUgUserGroup = new HashSet<ScUgUserGroup>();
            ScUgmUsergroupLinks = new HashSet<ScUgmUsergroupLinks>();
            ScUgmUsergroupModules = new HashSet<ScUgmUsergroupModules>();
        }

        public int SgsId { get; set; }
        public string SugName { get; set; }

        public virtual ICollection<ScUgUserGroup> ScUgUserGroup { get; set; }
        public virtual ICollection<ScUgmUsergroupLinks> ScUgmUsergroupLinks { get; set; }
        public virtual ICollection<ScUgmUsergroupModules> ScUgmUsergroupModules { get; set; }
    }
}
