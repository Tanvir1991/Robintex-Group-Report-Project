using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class CbmChequeBookRepository : GenericRepository<CbmChequeBook>, ICbmChequeBookRepository
    {
        private EmbroDBContext dbCon;
        public CbmChequeBookRepository(EmbroDBContext context)
         : base(context)
        {
            dbCon = context;
        }
        public async Task<RResult> UpdateCbmChequeBookStatus(string status, decimal ChkBkId,bool? saveChange=true)
        {
            RResult rResult = new RResult();
            var model =await dbCon.CbmChequeBook.Where(x => x.Id == ChkBkId).FirstAsync();
            model.Status = status;

            await dbCon.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
    }
}
