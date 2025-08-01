using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class KnittingNeedleConsumptionMasterViewModel
    {
        public int ID { get; set; }
        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Machine No")]
        public int MachineNo { get; set; }
        [Display(Name = "Consumption Date")]
        public DateTime ConsumptionDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateddDate { get; set; }
        public int? UpdatedBy { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> MachineNoList { get; set; }
        [Display(Name = "Broad Group One")]
        public int BroadGroupOne { get; set; }
        public List<SelectListItem> BroadGroupOneList { get; set; }
        [Display(Name = "Broad Group Two")]
        public int BroadGroupTwo { get; set; }
        public List<SelectListItem> BroadGroupTwoList { get; set; }
        [Display(Name = "Broad Group Three")]
        public int BroadGroupThree { get; set; }
        public List<SelectListItem> BroadGroupThreeList { get; set; }
        [Display(Name = "Item")]
        public int ItemID { get; set; }
        public List<SelectListItem> ItemList { get; set; }
        public bool IsEdit { get; set; }
        public string CreateDateTime { get; set; }
        [Display(Name = "Item Category")]
        public int ItemCategoryID { get; set; }
        public List<SelectListItem> ItemCategoryList { get; set; }
        public List<KnittingNeedleConsumptionDetailsViewModel> KnittingNeedleConsumptionDetails { get; set; }
    }
}
