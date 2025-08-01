using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class Tbl_KnittingMachinesService : ITbl_KnittingMachinesService
    {
        private readonly ITbl_KnittingMachinesRepository _tbl_KnittingMachinesRepository;
        public Tbl_KnittingMachinesService(ITbl_KnittingMachinesRepository tbl_KnittingMachinesRepository)
        {
            _tbl_KnittingMachinesRepository = tbl_KnittingMachinesRepository;
        }
         
        public async Task<List<SelectListItem>> DDLMachine(int CompanyID = 0)
        {
            return await _tbl_KnittingMachinesRepository.DDLMachine(CompanyID);
        }

        public async Task<List<SelectListItem>> DDLMachine(int CompanyID = 0, bool IsIncludeSubcontact = true)
        {
            return await _tbl_KnittingMachinesRepository.DDLMachine(CompanyID, IsIncludeSubcontact);
        }

        public async Task<Tbl_KnittingMachines> GetMachineInfo(int MachineNo)
        {
            return await _tbl_KnittingMachinesRepository.GetMachineInfo(MachineNo);
        }
    }
}
