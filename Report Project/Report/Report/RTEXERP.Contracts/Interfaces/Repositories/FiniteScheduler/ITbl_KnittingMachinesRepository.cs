using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
  public  interface ITbl_KnittingMachinesRepository :IGenericRepository<Tbl_KnittingMachines> 
    {
        Task<List<SelectListItem>> DDLMachine(int CompanyID = 0);
        Task<List<SelectListItem>> DDLMachine(int CompanyID = 0,bool IsIncludeSubcontact=true);
        Task<Tbl_KnittingMachines> GetMachineInfo(int MachineNo);
    }
}
