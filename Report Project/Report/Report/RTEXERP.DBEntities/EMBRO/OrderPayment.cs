using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class OrderPayment
    {
        public long OrderId { get; set; }
        public long VoucherId { get; set; }
        public long? Esvid { get; set; }
    }
}
