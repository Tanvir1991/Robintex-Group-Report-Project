using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrMsModuleSetup
    {
        public GrMsModuleSetup()
        {
            GrMlModuleLinks = new HashSet<GrMlModuleLinks>();
            ScUgmUsergroupModules = new HashSet<ScUgmUsergroupModules>();
        }

        public int GmsId { get; set; }
        public string GmsName { get; set; }
        public string GmsDesc { get; set; }
        public string GmsPath { get; set; }
        public bool? GmsActive { get; set; }

        public virtual ICollection<GrMlModuleLinks> GrMlModuleLinks { get; set; }
        public virtual ICollection<ScUgmUsergroupModules> ScUgmUsergroupModules { get; set; }
    }
}
