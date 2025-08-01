using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface ICBM_ChequeRepository:IGenericRepository<CbmCheque>
    {
        Task<InstrumentViewModel> GetInstrumentNo(int bankAccountId);
        Task<RResult> UpdateCbmCheque(CbmCheque model,bool? saveChange=true);

        Task<List<SelectListItem>> DDLIssuedCheque(int BankAccID);
    }
}
