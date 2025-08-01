using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.DBEntities.Hrm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Hrm
{

    public class Tbl_EmpService : ITbl_EmpService
    {
       private readonly ITbl_EmpRepository tbl_EmpRepository;
        public Tbl_EmpService(ITbl_EmpRepository tbl_EmpRepository)
        {
            this.tbl_EmpRepository = tbl_EmpRepository;

        }

        public string EnglishNumberToBangla(string Code)
        {
            return tbl_EmpRepository.EnglishNumberToBangla(Code);
        }

        public async Task<List<EmployeeElectionInfoViewModel>> GetEmployeeElectionInfo(string employeeCodeList)
        {
            return await tbl_EmpRepository.GetEmployeeElectionInfo(employeeCodeList);
        }

        public async Task<List<Tbl_EmpViewModel>> Get_EmpsForShiftReport(string EMPCode)
        {
            return await tbl_EmpRepository.Get_EmpsForShiftReport(EMPCode);
        }
    }
}