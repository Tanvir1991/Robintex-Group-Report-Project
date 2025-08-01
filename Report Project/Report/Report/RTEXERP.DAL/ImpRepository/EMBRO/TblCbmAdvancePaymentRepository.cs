using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class TblCbmAdvancePaymentRepository : GenericRepository<TblCbmAdvancePayment>, ITblCbmAdvancePaymentRepository
    {
        private EmbroDBContext dbCon;
        public TblCbmAdvancePaymentRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public Task<RResult> SaveTblCbmAdvancePayment(TblCbmAdvancePayment advPayment, bool? savechange)
        {
            throw new NotImplementedException();
        }

        public async Task<RResult> SaveTblCbmAdvancePayment(List<TblCbmAdvancePayment> advPaymentList, bool? savechange)
        {
            RResult rResult = new RResult();
            try
            {
                dbCon.TblCbmAdvancePayment.AddRange(advPaymentList);
                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.InsertMessage;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;
        }
    }
}
