using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GrRlRelatedLinks
    {
        public int GrlId { get; set; }
        public int GrlParentGmlid { get; set; }
        public int GrlRelatedGmlid { get; set; }
        public byte GrlRelationlevel { get; set; }
        public byte? GrlSequence { get; set; }

        public virtual GrMlModuleLinks GrlParentGml { get; set; }
        public virtual GrMlModuleLinks GrlRelatedGml { get; set; }
    }
}
