using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.FiniteScheduler
{
    public class DFS_LotMakingMaster
    {
        public long ID { get; set; }
        public string LotNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UserID { get; set; }
        public bool? Status { get; set; }
        public string Comments { get; set; }
        public double? HeatSetTemp { get; set; }
        public double? HeatSetSpeed { get; set; }
        public double? HeatSetOverFeed { get; set; }
        public double? HeatSetBlowSpeed { get; set; }
        public double? FinishSetTemp { get; set; }
        public double? FinishSetSpeed { get; set; }
        public double? FinishSetOverFeed { get; set; }
        public double? CompactorTemp { get; set; }
        public double? CompactorSpeed { get; set; }
        public double? CompactorOverFeed { get; set; }
    }
}
