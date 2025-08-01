using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
  public  class MAC_FabricCostingInfoVM
    {
        public int ID { get; set; }
        public int GSM { get; set; }
        public int? FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public int OrderCostingID { get; set; }
        [Display(Name ="Composition")]
        public string FabricCompisition { get; set; }
        [Display(Name = "Count")]
        public string YarnCount { get; set; }
        [Display(Name = "Color")]
        public string FabricColor { get; set; }
        [Display(Name = "Yarn Price")]
        public decimal YarnPrice { get; set; }
        [Display(Name = "Lycra Perc")]
        public decimal LycraCostPercent { get; set; }
        [Display(Name = "Lycra Cost")]
        public decimal LycraCost { get; set; }
        [Display(Name = "Knitting Cost")]
        public decimal KnittingCost { get; set; }
        [Display(Name = "Knitting W. Perc")]
        public decimal KnittingWastagePer { get; set; } = 1;
        [Display(Name = "Deying Costing")]
        public decimal DeyingCostSolid { get; set; }
        //public decimal DeyingCostAOP { get; set; } = 0;
        //[Display(Name = "Deying W. Perc")]
        public decimal DeyingWastagePer { get; set; } = 1;
        [Display(Name = "Leverage Perc")]
        public decimal LeveragePercent { get; set; } = 1;
        [Display(Name = "Total Price")]
        public decimal TotalPrice { get { return (((YarnPrice+LycraCost+KnittingCost)*KnittingWastagePer)+DeyingCostSolid)*DeyingWastagePer; } set { } }

        [Display(Name = "Contribution By")]
        public decimal TotalContribution { get { return TotalPrice * LeveragePercent /100; } }

       public MAC_OrderCostingInfoVM MAC_OrderCostingInfo { get; set; }


    }
}
