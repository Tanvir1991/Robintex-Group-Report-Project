using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
   public class KnittingProductionReportPageModel
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public int CompanyID { get; set; }
        public int MachineID { get; set; }
        public List<SelectListItem> DDLMachineCompany { get; set; }
        public List<SelectListItem> DDLMachine { get; set; }
    }
}
