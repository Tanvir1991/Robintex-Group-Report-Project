using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.DBEntities.Hrm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Hrm
{
  public  interface ITbl_EmpService
    {
        Task<List<Tbl_EmpViewModel>> Get_EmpsForShiftReport(string EMPCode);
        string EnglishNumberToBangla(string Code);
        Task<List<EmployeeElectionInfoViewModel>> GetEmployeeElectionInfo(string employeeCodeList);
    }
}
