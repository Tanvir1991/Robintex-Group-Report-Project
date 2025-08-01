using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class FabricBookingMasterViewModel
    {
        public FabricBookingMasterViewModel()
        {
            FabricBookingDetail = new List<FabricBookingDetailViewModel>();
        }
        
        public int BoookingMasterID { get; set; }
        public int FabricBookingID { get; set; }
        [Display(Name = "Buyer")]
        public int BuyerID { get; set; }
        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [Display(Name = "Style")]
        public int StyleID { get; set; }
        [Display(Name = "Delivery Start Date")]
        public DateTime DeliveryStartDate { get; set; }
        [Display(Name = "Delivery End Date")]
        public DateTime DeliveryEndDate { get; set; }
        [Display(Name = "Delivery Start Date")]
        public string DeliveryStartDateMsg { get; set; }
        [Display(Name = "Delivery End Date")]
        public string DeliveryEndDateMsg { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Special Instruction")]
        public string SpecialInstruction { get; set; }
        public string Reference { get; set; }
        [Display(Name = "Revision Reason")]
        public string RevisionReason { get; set; }
        public List<SelectListItem> BuyerList { get; set; }
        public List<SelectListItem> OrderList { get; set; }
        public List<SelectListItem> StyleList { get; set; }
        public List<FabricBookingDetailViewModel> FabricBookingDetail { get; set; }
    }
}
