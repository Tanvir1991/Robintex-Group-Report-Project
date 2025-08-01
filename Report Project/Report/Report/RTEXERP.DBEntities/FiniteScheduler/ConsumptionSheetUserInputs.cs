using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class ConsumptionSheetUserInputs
    {
        [Key]
        public int CSUIID { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public int? InspectionPcs { get; set; }
        public int? PanelRejectPcs { get; set; }
        public decimal? PanelRejectPercentage { get; set; }
        public int? TotalFinishFabricUsed { get; set; }
        public decimal? ALGOOSQty { get; set; }
        public decimal? TotalFinishFabricMayReq { get; set; }
    }
}
