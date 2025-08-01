using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class tbl_Currency_SetupService : Itbl_Currency_SetupService
    {
        private readonly Itbl_Currency_SetupRepository currency_SetupRepository;
        public tbl_Currency_SetupService(Itbl_Currency_SetupRepository currency_SetupRepository)
        {
            this.currency_SetupRepository = currency_SetupRepository;
        }
        public async Task<List<SelectListItem>> DDLCurrencyList()
        {
            return await currency_SetupRepository.DDLCurrencyList();
        }
        
    }
}
