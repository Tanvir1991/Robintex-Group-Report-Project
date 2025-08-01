using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class ApmInvoiceStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
    }
}
