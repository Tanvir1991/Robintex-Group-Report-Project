using System;
using System.Collections.Generic;

namespace RTEXERP.DBEntities.Embro
{
    public partial class StoresInformation
    {
        public StoresInformation()
        {
            InventoryInformation = new HashSet<InventoryInformation>();
        }

        public int Id { get; set; }
        public decimal? CompanyId { get; set; }
        public string StoreName { get; set; }
        public string StoreCode { get; set; }
        public string Initials { get; set; }
        public string StoreIncharge { get; set; }

        public virtual BasicCoa Company { get; set; }
        public virtual ICollection<InventoryInformation> InventoryInformation { get; set; }
    }
}
