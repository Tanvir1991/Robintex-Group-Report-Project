using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement
{
    public class POSearchViewModel
    {
       public DateTime POCreatetionDateFrom { get; set; }
        public DateTime POCreatetionDateTo { get; set; }
        public string POCreatetionDateFromSTR { get; set; }
        public string POCreatetionDateToSTR { get; set; }
        public int POID {get;set;}
        public int OrderID { get; set; }
        public int StatusID { get; set; } 


        public List<SelectListItem> DDLPO { get; set; }
        public List<SelectListItem> DDDLOrder { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }
        
    }
}
