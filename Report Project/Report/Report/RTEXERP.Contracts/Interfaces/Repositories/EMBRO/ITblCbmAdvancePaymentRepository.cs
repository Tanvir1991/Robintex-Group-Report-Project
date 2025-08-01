using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
    public interface ITblCbmAdvancePaymentRepository:IGenericRepository<TblCbmAdvancePayment>
    {
        Task<RResult> SaveTblCbmAdvancePayment(TblCbmAdvancePayment advPayment, bool? savechange);
        Task<RResult> SaveTblCbmAdvancePayment(List<TblCbmAdvancePayment> advPaymentList,bool? savechange);
    }
}
