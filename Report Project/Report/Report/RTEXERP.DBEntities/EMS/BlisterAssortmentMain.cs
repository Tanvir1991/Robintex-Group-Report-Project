using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class BlisterAssortmentMain
    {
        public int Id { get; set; }
        public int? NoOfMasterPoly { get; set; }
        public long? NoOfGarments { get; set; }
        public int? MasterPolyId { get; set; }
        public DateTime? AssortmentDate { get; set; }
        public bool? IsEdited { get; set; }
        public bool? IsDeleted { get; set; }
        public int? PackingStatus { get; set; }
        public long? StyleId { get; set; }
        public int? Poid { get; set; }
    }
}
