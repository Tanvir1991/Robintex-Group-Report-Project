using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
   public class MAC_OrderCostingListVM
    {
        public int? OrderCostingID { get; set; }
        [Display(Name ="Buyer")]
        public int? BuyerID { get; set; }
        [Display(Name = "Order")]
        public string OrderNo { get; set; }
        [Display(Name = "Style")]
        public string StyleName { get; set; }
        [Display(Name = "Fabric Composition")]
        public string FabricInfo { get; set; }
        [Display(Name = "Date From")]
        public string DateFromSTR { get; set; }
        [Display(Name = "Date To")]
        public string DateToSTR { get; set; }

        public List<SelectListItem> DDLBuyer { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLStyle { get; set; }
    }
}
