using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.FiniteScheduler
{
    public class LotWiseCuttingInfoViewModel
    {
        public LotWiseCuttingInfoViewModel()
        {
            LotWiseCuttingInfoMarkers = new List<LotWiseCuttingInfoMarkersViewModel>();
            LotWiseShortCuttingInfo = new List<LotWiseShortCuttingInfoViewModel>();
        }
        public long CuttingInfoID { get; set; }
        [Display(Name ="Orderno")]
        public long OrderID { get; set; }
        [Display(Name = "Orderno")]
        public string OrderNo { get; set; }
        [Display(Name = "Date")]
        public DateTime CuttingReportingDate { get; set; }
        [Display(Name = "Date")]
        public string CuttingReportingDateMsg { get; set; }
        [Display(Name = "Lotno")]
        public int LotID { get; set; }
        [Display(Name = "Lotno")]
        public string LotNo { get; set; }
        [Display(Name = "Pantone")]
        public string Color { get; set; }
        [Display(Name = "Pantone")]
        public string PantoneNo { get; set; }
        public decimal LotFinishQuantity { get; set; }
        public decimal LotQuantity { get; set; }        
        public bool HasShortCutting { get; set; }
        public int? MarkerCuttingPlanMaster_ExcelID { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<LotWiseCuttingInfoMarkersViewModel> LotWiseCuttingInfoMarkers { get; set; }
        public List<LotWiseShortCuttingInfoViewModel> LotWiseShortCuttingInfo { get; set; }

        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> LotList { get; set; }
        public List<SelectListItem> MarkerList { get; set; }
        public List<SelectListItem> ColorList { get; set; }

        
    }
}
