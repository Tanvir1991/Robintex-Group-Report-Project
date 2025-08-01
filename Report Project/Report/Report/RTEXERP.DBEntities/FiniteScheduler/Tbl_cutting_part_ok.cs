using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class Tbl_cutting_part_ok
    {
        public long ID { get; set; }
        public long? LotID { get; set; }
        public long? ttl_cut_pc { get; set; }
        public long? ttl_ok_cut_pc { get; set; }
        public string Comment { get; set; }
        public DateTime InspectionDate { get; set; }
        public long? user_id { get; set; }
        public long? Cutting_no { get; set; }
        public long? challan_id { get; set; }
        public string inspectorname { get; set; }
        public decimal? Defect_Pert_Weight { get; set; }
        public long? challan_id_Short { get; set; }
        public int? Active { get; set; }
    }
}
