using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class SFS_ProductionResourceRelations
    {
        public int ID { get; set; }
        public int? ParentSFS_PRSID { get; set; }
        public int ChildSFS_PRSID { get; set; }
    }
}
