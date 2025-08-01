using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm
{
    public class EmployeeElectionInfoViewModel
    {
        public long Emp_ID { get; set; }
        public string Emp_Cd { get; set; }
        public string Emp_oldNo { get; set; }
        public string Emp_oldNoBN { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Bname { get; set; }
        public string Cmp_Name { get; set; }
        public string CompanyNameBN { get; set; }
        public string Designation_Name { get; set; }
        public string Designation_Bname { get; set; }
        public string Dept_Name { get; set; }
        public string Dept_BName { get; set; }
        public string Section_Name { get; set; }
        public string Section_BName { get; set; }

        public string ElectionYear { get; set; }


    }

    public class ElectionMemberList
    {
        public string MemberGroup { get; set; }
        public List<EmployeeElectionInfoViewModel> ElectionMembers { get; set; }
    }
}
