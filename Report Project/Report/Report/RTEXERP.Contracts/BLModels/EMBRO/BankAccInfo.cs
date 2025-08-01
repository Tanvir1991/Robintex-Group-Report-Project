using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.EMBRO
{
    public class BankAccInfo
    {
        public int BankID { get; set; }
        public int BranchID { get; set; }
        public int AccID { get; set; }
        public int ChequeNumber { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLBranch { get; set; }
        public List<SelectListItem> DDLAcc { get; set; }
        public List<SelectListItem> DDLChequeNumber { get; set; }
        public List<SelectListItem> DDLCompany { get; set; }
        
        public int CompanyID { get; set; }

    }
}
