using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CBM_BankAccountSetupServie : ICBM_BankAccountSetupServie
    {
        private readonly ICBM_BankAccountSetupRepository iCBM_BankAccountSetupRepository;
        public CBM_BankAccountSetupServie(ICBM_BankAccountSetupRepository iCBM_BankAccountSetupRepository)
        {
            this.iCBM_BankAccountSetupRepository = iCBM_BankAccountSetupRepository;
        }
        public async Task<List<SelectListItem>> DDLBankAccount(decimal CompanyID, int BranchID)
        {
            return await this.iCBM_BankAccountSetupRepository.DDLBankAccount(BranchID);
        }
    }
}
