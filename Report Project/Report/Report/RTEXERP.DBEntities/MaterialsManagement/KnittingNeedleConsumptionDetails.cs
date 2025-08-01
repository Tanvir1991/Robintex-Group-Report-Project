using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
   public class KnittingNeedleConsumptionDetails 
    {
        public int ID { get; set; }
        [ForeignKey("KnittingNeedleConsumptionMaster")]
        public int KnittingNeedleConsumptionMasterID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public decimal UnitRate { get; set; }
        public int? KnittingRepairItemCategoryID { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateddDate { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual KnittingNeedleConsumptionMaster KnittingNeedleConsumptionMaster { get; set; }
    }
}
