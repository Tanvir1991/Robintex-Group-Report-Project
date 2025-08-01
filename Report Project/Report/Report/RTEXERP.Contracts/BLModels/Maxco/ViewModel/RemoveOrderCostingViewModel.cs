using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Maxco.ViewModel
{
    public class RemoveOrderCostingViewModel
    {
        [Display(Name="Order No")]
        public string CostingID { get; set; }
       
        public string Remarks { get; set; }

        public List<SelectListItem> DDLOrderNo { get; set; }

    }
}
