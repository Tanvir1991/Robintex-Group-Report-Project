using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class TransferedFabricInfoSearchVM
    {
        [Display(Name = "Adjustment Type")]
        public int FabricAdjustmentTransferTypeID { get; set; }
        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name ="Transfer Type")]
        public string ReceiveType { get; set; }
        public List<SelectListItem> DDLOrder { get; set; }
        public List<SelectListItem> DDLFabricAdjustmentTransfer { get; set; }
        public List<SelectListItem> DDLReceiveType { get; set; }

    }
}
