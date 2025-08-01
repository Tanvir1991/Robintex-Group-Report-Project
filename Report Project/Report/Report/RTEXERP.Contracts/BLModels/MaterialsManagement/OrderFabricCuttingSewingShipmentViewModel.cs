using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
  public  class OrderFabricCuttingSewingShipmentViewModel
    {
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<SelectListItem> DDLBuyerList { get; set; }
        public List<SelectListItem> DDLOrderList { get; set; }

    }
}
