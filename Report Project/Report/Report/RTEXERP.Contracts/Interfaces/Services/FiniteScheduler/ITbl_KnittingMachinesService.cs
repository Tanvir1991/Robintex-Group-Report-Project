using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
  public  interface ITbl_KnittingMachinesService
    {
        Task<List<SelectListItem>> DDLMachine(int CompanyID = 0, bool IsIncludeSubcontact = true);
        Task<List<SelectListItem>> DDLMachine(int CompanyID = 0);
        Task<Tbl_KnittingMachines> GetMachineInfo(int MachineNo);
    }
}
