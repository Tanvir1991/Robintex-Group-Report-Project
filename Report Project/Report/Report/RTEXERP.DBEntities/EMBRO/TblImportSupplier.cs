using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class TblImportSupplier
    {
        public decimal Id { get; set; }
        public int? ParentId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public int? Levelid { get; set; }
        public int? CompId { get; set; }
    }
}
