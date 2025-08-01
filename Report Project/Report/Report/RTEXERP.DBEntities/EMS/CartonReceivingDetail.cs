using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.EMS
{
    public partial class CartonReceivingDetail
    {
        public long Id { get; set; }
        public long? Rid { get; set; }
        public long? CartonId { get; set; }
        public long? Poid { get; set; }
    }
}
