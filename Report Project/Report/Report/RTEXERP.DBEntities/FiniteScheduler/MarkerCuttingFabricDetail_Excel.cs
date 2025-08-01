using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class MarkerCuttingFabricDetail_Excel
    {        
        [Key]
        public long MCFabricDetailID { get; set; }
        [ForeignKey("MarkerCuttingPlanMaster_Excel")]
        public long MCPMID { get; set; }
        public string PieceName { get; set; }
        public string FabricType { get; set; }
        public int GSM { get; set; }
        public int Dia { get; set; }
        public decimal ConsKgPerDzn { get; set; }
        public virtual MarkerCuttingPlanMaster_Excel MarkerCuttingPlanMaster_Excel { get; set; }

    }
}
