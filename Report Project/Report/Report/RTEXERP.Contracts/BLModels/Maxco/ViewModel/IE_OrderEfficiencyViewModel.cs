using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
  public  class IE_OrderEfficiencyViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }

        [Required]
        [Display(Name = "Order")]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime ReportDate { get; set; }
        [Required]
        public string ReportDateSTR { get; set; }

        [Required]
        [Display(Name = "Style")]
        public int StyleID { get; set; }
        [Required]
        [Display(Name = "Line")]
        public int LineID { get; set; }

        [Display(Name = "Pantone")]
        public string PantoneNo { get; set; }
        [Display(Name = "Hourly Target Production")]
        public int HourlyTargetProduction { get; set; }
        [Display(Name = "Target Effiency")]
        public decimal TargetEffiency { get; set; }
        [Display(Name = "SMV")]
        public decimal OrderSMV { get; set; }
        public string Remarks { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        [Display(Name = "W. Hour")]
        public decimal? WorkingHour { get; set; }
        [Display(Name = "Manpower")]
        public int ? LineManpower { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> StyleList { get; set; }
        public List<SelectListItem> PantoneNoList { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> DDLProductionLine { get; set; }
        public List<OrderEfficiencyDataModel> OrderEfficiency { get; set; }
    }
}
