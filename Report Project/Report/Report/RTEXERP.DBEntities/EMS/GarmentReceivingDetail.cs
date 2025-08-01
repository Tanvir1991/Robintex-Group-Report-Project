using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class GarmentReceivingDetail
    {
        public int Id { get; set; }
        public int? RecId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int? Garments { get; set; }
    }
}
