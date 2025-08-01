using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class MarkerCuttingConsumption_Excel
    {
        [Key]
        public long MCConsumptionID { get; set; }
        [ForeignKey("MarkerCuttingInfo_Excel")]
        public long MCInfoID { get; set; }
        public int BaseQty { get; set; }
        public decimal ConsPerPcs { get; set; }
        public decimal AvgCons { get; set; }
        public virtual MarkerCuttingInfo_Excel MarkerCuttingInfo_Excel { get; set; }
    }
}
