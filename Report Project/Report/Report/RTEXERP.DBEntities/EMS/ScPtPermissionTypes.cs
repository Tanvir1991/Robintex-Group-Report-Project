using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class ScPtPermissionTypes
    {
        public ScPtPermissionTypes()
        {
            ScUgmUsergroupModules = new HashSet<ScUgmUsergroupModules>();
        }

        public byte PtId { get; set; }
        public string PtName { get; set; }

        public virtual ICollection<ScUgmUsergroupModules> ScUgmUsergroupModules { get; set; }
    }
}
