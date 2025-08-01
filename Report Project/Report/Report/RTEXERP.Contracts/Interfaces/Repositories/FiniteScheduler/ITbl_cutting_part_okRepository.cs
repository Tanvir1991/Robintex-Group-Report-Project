using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
    public interface ITbl_cutting_part_okRepository:IGenericRepository<Tbl_cutting_part_ok>
    {
        Task<List<SelectListItem>> DDLLotForCuttingDefect(int? LotUptoLast);
    }
}
