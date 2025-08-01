using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmPaymentModesDetail
    {
        public decimal Mopid { get; set; }
        public decimal SupplierId { get; set; }

        public virtual ApmPaymentModes Mop { get; set; }
        public virtual SupplierSetup Supplier { get; set; }
    }
}
