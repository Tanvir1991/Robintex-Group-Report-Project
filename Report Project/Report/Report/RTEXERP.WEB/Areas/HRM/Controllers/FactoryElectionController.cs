using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RTEXERP.Contracts.BLModels.Hrm;
using RTEXERP.Contracts.Interfaces.Repositories.Hrm;
using RTEXERP.Contracts.Interfaces.Services.Hrm;
using RTEXERP.WEB.Controllers;

namespace RTEXERP.WEB.Areas.HRM.Controllers
{
    [Area("HRM")]
    public class FactoryElectionController : BaseController
    {
        private readonly ITbl_EmpService tbl_EmpService;
        private readonly IElectionMemberTypeRepository electionMemberTypeRepository;
        public FactoryElectionController(ITbl_EmpService tbl_EmpService, IElectionMemberTypeRepository electionMemberTypeRepository)
        {
            this.tbl_EmpService = tbl_EmpService;
            this.electionMemberTypeRepository = electionMemberTypeRepository;
        }
        public async Task<IActionResult> SearchElectionIdentity()
        {
            ElectionMemberSelectionViewModel model = new ElectionMemberSelectionViewModel();
            model.DDLElectionMemberType = await electionMemberTypeRepository.DDLElectionType() ;
            return View(model);
        }
        public async Task<IActionResult> ElectionIdentity(int Id,string empList)
        {
            ElectionMemberList members = new ElectionMemberList();
            var typename =await electionMemberTypeRepository.GetByIdAsync(Id);
            members.MemberGroup = typename.TypeNameBN;

            var employeeInfoList = await tbl_EmpService.GetEmployeeElectionInfo(empList);
            members.ElectionMembers = employeeInfoList;
            return View(members);
        }
    }
    
}
