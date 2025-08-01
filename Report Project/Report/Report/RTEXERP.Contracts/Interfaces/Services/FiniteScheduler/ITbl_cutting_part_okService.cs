using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
    public interface ITbl_cutting_part_okService
    {
        Task<List<SelectListItem>> DDLLotForCuttingDefect(int? LotUptoLast);
    }
}
