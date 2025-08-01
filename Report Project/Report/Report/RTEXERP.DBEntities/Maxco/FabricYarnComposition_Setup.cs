using System;
using System.Collections.Generic;


namespace RTEXERP.DBEntities.Maxco
{
    public partial class FabricYarnComposition_Setup 
    {
       

        public int ID { get; set; }
        public string Description { get; set; }
        public bool? IsMix { get; set; }
        public double? CottonRatio { get; set; }
        public double? PolyesterRatio { get; set; }
        public double? LycraRatio { get; set; }
      
        public long? isNewComposition { get; set; }
        public double? CnvCtnRatio { get; set; }
        public double? OrgCtnRatio { get; set; }
        public int? IsDeleted { get; set; }

        


    }
}
