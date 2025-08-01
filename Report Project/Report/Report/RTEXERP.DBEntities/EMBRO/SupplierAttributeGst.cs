using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SupplierAttributeGst
    {
        public long AttributeId { get; set; }
        public long SupplierId { get; set; }
        public double SalesTax { get; set; }
        public long? SalesTaxAccountId { get; set; }
        public int UserId { get; set; }
        public byte Deleted { get; set; }
        public int FiscalYear { get; set; }
    }
}
