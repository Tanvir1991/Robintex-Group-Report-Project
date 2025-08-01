using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class AccOrderWiseStatusViewModel
    {
        public int ID { get; set; }
        [Display(Name ="Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }
        public string DateFromSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public string DateToSTR { get { return DateFrom.ToString("dd-MMM-yyyy"); } }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> OrderList { get; set; }
    }
}
