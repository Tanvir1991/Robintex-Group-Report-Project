using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GarmentReceivingMain
    {
        public int Id { get; set; }
        public string RecNo { get; set; }
        public DateTime? RecDate { get; set; }
        public string RecPerson { get; set; }
        public string RecChallan { get; set; }
        public int? Poid { get; set; }
        public int? PackingAreaId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
