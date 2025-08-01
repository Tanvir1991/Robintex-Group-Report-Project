using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class EmPcdPackingCartonDetail
    {
        public long EpcdId { get; set; }
        public int? EpcdEpmId { get; set; }
        public int? EpcdCartonId { get; set; }
        public int? EpcdColorId { get; set; }
        public int? EpcdSizeId { get; set; }
        public int? EpcdGarments { get; set; }
        public int? EpcdEpdId { get; set; }
    }
}
