using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SupplierAttributeExDty
    {
        public long AttributeId { get; set; }
        public long SupplierId { get; set; }
        public double ExciseDuty { get; set; }
        public long? ExciseDutyAccountId { get; set; }
        public int UserId { get; set; }
        public byte Deleted { get; set; }
        public int FiscalYear { get; set; }
    }
}
