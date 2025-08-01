using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
   public class AccCommonModel
    {
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public IEnumerable<SelectListItem> DDLCompany { get; set; }
        public IEnumerable<SelectListItem> DDLBusiness { get; set; }

    }
}
