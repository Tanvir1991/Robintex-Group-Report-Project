using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.MaterialsManagement
{
    public class DD_POItemDetails
    {
        public int ID { get; set; }
        public double Quantity { get; set; }
        public string DeliveryDate { get; set; }
        public string Remarks { get; set; }
        public int POItemMasterID { get; set; }
        public int? DeliveryPointID { get; set; }
        public double? Rate { get; set; }
        public double? Balance { get; set; }
        public double? ConvPrice { get; set; }
        public double? CurrencyRate { get; set; }
        public int? CurrencyID { get; set; }

        public DD_POItemMaster DD_POItemMaster { get; set; }
    }
}
