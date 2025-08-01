using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CBM_BankService : ICBM_BankService
    {
        private readonly ICBM_BankRepository iCBM_BankRepository;
        public CBM_BankService(ICBM_BankRepository iCBM_BankRepository)
        {
            this.iCBM_BankRepository = iCBM_BankRepository;

        }
        public async Task<List<SelectListItem>> DDLBank(decimal CompanyID)
        {
            return await iCBM_BankRepository.DDL_CBM_Bank(CompanyID);
        }
    }
}
