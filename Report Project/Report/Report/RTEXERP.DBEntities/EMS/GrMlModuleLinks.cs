using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrMlModuleLinks
    {
        public GrMlModuleLinks()
        {
            GrLpLinkPages = new HashSet<GrLpLinkPages>();
            GrRlRelatedLinksGrlParentGml = new HashSet<GrRlRelatedLinks>();
            GrRlRelatedLinksGrlRelatedGml = new HashSet<GrRlRelatedLinks>();
            ScUgmUsergroupLinks = new HashSet<ScUgmUsergroupLinks>();
        }

        public int GmlId { get; set; }
        public string GmlName { get; set; }
        public string GmlDesc { get; set; }
        public byte GmlLevel { get; set; }
        public int? GmlParentid { get; set; }
        public bool GmlActive { get; set; }
        public int GmsId { get; set; }
        public byte? GmlIsworkflow { get; set; }
        public byte? GmlIsapprovaldoc { get; set; }
        public string GmlDocreportlink { get; set; }
        public string GmlDasParenttable { get; set; }

        public virtual GrMsModuleSetup Gms { get; set; }
        public virtual ICollection<GrLpLinkPages> GrLpLinkPages { get; set; }
        public virtual ICollection<GrRlRelatedLinks> GrRlRelatedLinksGrlParentGml { get; set; }
        public virtual ICollection<GrRlRelatedLinks> GrRlRelatedLinksGrlRelatedGml { get; set; }
        public virtual ICollection<ScUgmUsergroupLinks> ScUgmUsergroupLinks { get; set; }
    }
}
