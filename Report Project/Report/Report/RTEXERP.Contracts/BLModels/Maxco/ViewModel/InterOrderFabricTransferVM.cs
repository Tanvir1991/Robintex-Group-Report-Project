using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class InterOrderFabricTransferVM
    {
        [Display(Name = "Transfer Date")]
        public string TransferDate { get; set; }
        [Display(Name = "Transfer From Order")]
        public int TransferedFromOrderID { get; set; }
        [Display(Name = "Transfer To Order")]
        public int TransferedToOrderID { get; set; }
        [Display(Name = "Transfer Type")]
        public int TransferTypeID { get; set; }
        public List<SelectListItem> DDLFromOrder { get; set; }
        public List<SelectListItem> DDLToOrder { get; set; }
        public List<SelectListItem> DDLTransferType { get; set; }
    }
}
