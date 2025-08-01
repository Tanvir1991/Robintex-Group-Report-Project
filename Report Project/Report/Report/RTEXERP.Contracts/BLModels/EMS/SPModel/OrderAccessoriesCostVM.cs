using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMS.SPModel
{
   public class OrderAccessoriesCostVM
    {
        [Display(Name ="Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Order No")]
        public int OrderID { get; set; }
        public string  DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> OrderList { get; set; }
    }
}
