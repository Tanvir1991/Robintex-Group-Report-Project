using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
  public  class KnittingNeedleConsumptionMaster
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int MachineNo { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateddDate { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual List<KnittingNeedleConsumptionDetails> KnittingNeedleConsumptionDetails { get; set; }

    }
}
