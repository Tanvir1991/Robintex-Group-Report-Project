using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
   public class EmployeeAttendancePageViewModel
    {
        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        [Display(Name = "Attendance Status")]
        public int StatusID { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        [Display(Name = "Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [Display(Name = "Present Status")]
        public int PresentStatusID { get; set; }
        public List<SelectListItem> PresentStatusList { get; set; }

    }
}
