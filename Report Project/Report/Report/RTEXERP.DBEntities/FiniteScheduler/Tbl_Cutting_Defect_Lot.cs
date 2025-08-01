using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class Tbl_Cutting_Defect_Lot
    {
        public int ID { get; set; }
        public int LotID { get; set; }
        public decimal LotReceivedKG { get; set; }
        public string ChallanNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsRemoved { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
