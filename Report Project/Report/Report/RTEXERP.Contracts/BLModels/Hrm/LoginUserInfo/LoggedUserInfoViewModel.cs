using System;
using System.Collections.Generic;
using System.Text;

namespace RTEXERP.Contracts.BLModels.Hrm.LoginUserInfo
{
    public class LoggedUserInfoViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeName { get; set; }
        public bool IsSuperAdminRole { get; set; }
        public string RoleName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }



    }
}
