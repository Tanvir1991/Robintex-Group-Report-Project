using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.DBEntities.CMS
{
    public class DepartmentSalaryForProduction
    {
        public int ID { get; set; }
        public DateTime SalaryDate { get; set; }
        public string ReportName { get; set; }
        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? SectionID { get; set; }
        public string SectionName { get; set; }
        public int? ManPower { get; set; }
        public decimal? SalaryCost { get; set; }
        public decimal? OtherCost { get; set; }
        public decimal? OTCost { get; set; }
        public decimal? OtherOTCost { get; set; }
        public decimal? OverHeadCost { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
