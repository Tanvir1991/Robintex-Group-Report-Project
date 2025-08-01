using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
    public class ProductionLineEmployee
    {
        public int ID { get; set; }
        public DateTime SalaryDate { get; set; }
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public string Emp_CD { get; set; }
        public string Emp_OldNo { get; set; }
        public string EMP_Name { get; set; }
        public string DesignationName { get; set; }
        public string EmployeeType { get; set; }
    }
}
