using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
   public class ElectionMemberSelectionViewModel
    {
        [Display(Name= "EMP Code :")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Member Type :")]
        public int ElectionMemberType { get; set; }
        public List<SelectListItem> DDLElectionMemberType { get; set; }
    }
}
