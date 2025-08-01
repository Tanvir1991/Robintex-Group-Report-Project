using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CBM_ChequeService : ICBM_ChequeService
    {
        private readonly ICBM_ChequeRepository cBM_ChequeRepository;
        public CBM_ChequeService(ICBM_ChequeRepository cBM_ChequeRepository)
        {
            this.cBM_ChequeRepository = cBM_ChequeRepository;

        }
        public async Task<List<SelectListItem>> DDLIssuedCheque( int BankAccID)
        {
            return await cBM_ChequeRepository.DDLIssuedCheque(BankAccID);
        }
    }
}
