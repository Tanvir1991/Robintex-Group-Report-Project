using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class Mer_StyleMasterVM
    {
        public Mer_StyleMasterVM()
        {
            Mer_StylePODetail = new List<Mer_StylePODetailVM>();
        }
        public int StyleMasterID { get; set; }
        [Display(Name="Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Location Region")]
        public int ZoneID { get; set; }
        [Display(Name = "Season")]
        public int SeasonID { get; set; }
        [Display(Name = "Style")]
        public string StyleNo { get; set; }
        [Display(Name = "No Of PO")]
        public int NoOfPO { get; set; }
        [Display(Name = "No Of Color")]
        public int NoOfColor { get; set; }
        [Display(Name = "No Of Size")]
        public int NoOfSize { get; set; }       
        public string SeasonCode { get; set; }
        public string ZoneCode { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<DropDownItem> ZoneList { get; set; }
        public List<DropDownItem> SeasonList { get; set; }
        public List<SelectListItem> NoList { get; set; }
        public List<Mer_StylePODetailVM> Mer_StylePODetail { get; set; }
       
    }
}
