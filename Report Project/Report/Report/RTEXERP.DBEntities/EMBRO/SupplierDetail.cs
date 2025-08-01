using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class SupplierDetail
    {
        public decimal SupplierId { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public decimal Uid { get; set; }
    }
}
