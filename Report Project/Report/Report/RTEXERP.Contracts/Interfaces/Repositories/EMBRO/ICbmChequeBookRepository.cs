using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface ICbmChequeBookRepository:IGenericRepository<CbmChequeBook>
    {
        Task<RResult> UpdateCbmChequeBookStatus(string status, decimal ChkBkId, bool? saveChange = true);
    }
}
