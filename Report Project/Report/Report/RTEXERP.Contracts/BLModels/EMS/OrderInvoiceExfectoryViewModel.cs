using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMS
{
    public class OrderInvoiceExfectoryViewModel
    {

        public int BuyerID { get; set; }
        public int OrderID { get; set; }

        public string InvoiceNo { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public string ShipTo { get; set; }

        public List<SelectListItem> DDLBuyer { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLShipTo { get; set; }

    }
}
