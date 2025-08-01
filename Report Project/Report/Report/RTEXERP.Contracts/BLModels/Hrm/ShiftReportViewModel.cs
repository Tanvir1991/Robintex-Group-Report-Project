using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
    public class ShiftReportViewModel
    {
        public ShiftReportViewModel() 
        {
            EmpList = new List<Tbl_EmpViewModel>();
        }
        public string AShift { get; set; }
        public string BShift { get; set; }
        public string CShift { get; set; }
       public  List<Tbl_EmpViewModel> EmpList { get; set; }
    }

}
