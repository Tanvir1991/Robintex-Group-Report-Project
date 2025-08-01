using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Services.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.FiniteScheduler
{
    public class Tbl_cutting_part_okService: ITbl_cutting_part_okService
    {
        private readonly ITbl_cutting_part_okRepository tbl_Cutting_Part_OkRepository;

        public Tbl_cutting_part_okService(ITbl_cutting_part_okRepository _tbl_Cutting_Part_OkRepository)
        {
            tbl_Cutting_Part_OkRepository = _tbl_Cutting_Part_OkRepository;
        }

        public async Task<List<SelectListItem>> DDLLotForCuttingDefect(int? LotUptoLast)
        {
            return await tbl_Cutting_Part_OkRepository.DDLLotForCuttingDefect(LotUptoLast);
        }
    }
}
