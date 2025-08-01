using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class UtilityInformation
    {
        public int ItemId { get; set; }
        public int ParentId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int? StoreId { get; set; }
        public string ItemDesc { get; set; }
        public string Unit { get; set; }
        public string ConsumerNumber { get; set; }
        public string AccountNumber { get; set; }
    }
}
