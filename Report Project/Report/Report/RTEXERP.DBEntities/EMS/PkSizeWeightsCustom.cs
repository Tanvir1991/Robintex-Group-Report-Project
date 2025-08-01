using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class PkSizeWeightsCustom
    {
        public long Id { get; set; }
        public long? EpmId { get; set; }
        public long? StyleId { get; set; }
        public long? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? Weight { get; set; }
    }
}
