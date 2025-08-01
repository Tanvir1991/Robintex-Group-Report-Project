using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class Fapayment
    {
        public decimal PaymentId { get; set; }
        public byte? PaymentType { get; set; }
        public decimal? Identifier { get; set; }
    }
}
