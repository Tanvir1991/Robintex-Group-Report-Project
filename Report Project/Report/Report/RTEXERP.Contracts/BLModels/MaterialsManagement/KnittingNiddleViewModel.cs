using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
  public  class KnittingNiddleViewModel
    {
        [Display(Name ="Company")]
        public int CompanyID { get; set; }
        [Display(Name = "Machine No")]
        public int MachineNo { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        public List<SelectListItem> MachineNoList { get; set; }
        public List<SelectListItem> CompanyList { get; set; }

        public List<KnittingNeedleConsumptionViewModel> KnittingNeedleConsumption { get; set; }
    }
}
