using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class VoucherLog
    {
        public long Id { get; set; }
        public long? VoucherId { get; set; }
        public string Comments { get; set; }
        public DateTime? CoomentsDate { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
