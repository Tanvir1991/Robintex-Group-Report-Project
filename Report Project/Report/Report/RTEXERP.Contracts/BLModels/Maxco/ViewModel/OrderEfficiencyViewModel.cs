using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
  public  class OrderEfficiencyViewModel
    {
        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Style")]
        public int StyleID { get; set; }
        [Display(Name = "Pantone No")]
        public string PantoneNo { get; set; }
        public bool IsSupperAdmin { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> StyleList { get; set; }
        public List<SelectListItem> PantoneNoList { get; set; }
         public List<OrderEfficiencyDataModel> OrderEfficiency { get; set; }
    }
}
