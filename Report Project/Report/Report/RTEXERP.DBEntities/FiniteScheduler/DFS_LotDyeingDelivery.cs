using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class DFS_LotDyeingDelivery
    {
        public int ID { get; set; }
        public long LotID { get; set; }
        public DateTime LotConfirmDate { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
                     
        public DateTime? UpdatedDate { get; set; }
        public string Remarks { get; set; }
    }
}
