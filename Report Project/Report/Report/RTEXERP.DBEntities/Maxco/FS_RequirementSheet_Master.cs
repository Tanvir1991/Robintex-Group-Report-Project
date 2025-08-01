using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.Maxco
{
    public class FS_RequirementSheet_Master
    {
        [Key]
        public int RequirementSheetID { get; set; }

        public string ReqNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime GenerationDate { get; set; }
        public int? UserID { get; set; }
        public int? OrderID { get; set; }
        public string OrderNo { get; set; }
        public int? StyleID { get; set; }
        public string StyleName { get; set; }
        public string CostingXML { get; set; }
        public long? RejectionSRSMasterID { get; set; }
        public string Comments { get; set; }
        public bool? IsSRS { get; set; }
        public int? ConsolidatedRejectedID { get; set; }
        public int? DayEndStatus { get; set; }
    }
}
