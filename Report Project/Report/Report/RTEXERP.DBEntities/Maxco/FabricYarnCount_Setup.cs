using System;
using System.Collections.Generic;
 

namespace   RTEXERP.DBEntities.Maxco
{
    public partial class FabricYarnCount_Setup 
    {
          
        public long ID { get; set; }
        public string Description { get; set; }
        public int? FabricYarnCompositionID { get; set; }
        public int IsDisplay { get; set; }
        public string DesFYCI { get; set; }
        public int? IsDeleted { get; set; }
 
    }
}
