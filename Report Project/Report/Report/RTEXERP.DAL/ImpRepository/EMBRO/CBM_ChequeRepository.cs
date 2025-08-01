using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.EMBRO;
using RTEXERP.Contracts.Common;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.Extension;
using RTEXERP.DBEntities.Embro;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{
    public class CBM_ChequeRepository : GenericRepository<CbmCheque>, ICBM_ChequeRepository
    {
        private EmbroDBContext dbCon;
        public CBM_ChequeRepository(EmbroDBContext context)
         : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLIssuedCheque(int BankAccID)
        {
            var _fiscalYear = @"SELECT   ltrim(cast((select startmonth FROM FiscalYearSetup)AS VARCHAR(2))) + '/1/' + ltrim(str(MAX(ob.FiscalYear)-1)) as FiscaleDate
                                             FROM OpeningBalances AS ob";
            var fiscaleDT = dbCon.DataTableSqlQuery(_fiscalYear, new DbParameter[0]);
            var FiscaleDate = Convert.ToDateTime(fiscaleDT.Rows[0]["FiscaleDate"].ToString());

            var sql = from chqBook in dbCon.CbmChequeBook
                      join chq in dbCon.CbmCheque on chqBook.Id equals chq.ChqBkId
                      where chqBook.AccountId == BankAccID
                       && chq.ChqDate >= FiscaleDate
                       && (chq.Status==6 || chq.Status==7)
                      select new SelectListItem
                      {
                          Text = chq.ChqNum,
                          Value = chq.ChqId.ToString()
                      };
            return await sql.ToListAsync();
        }

        public async Task<InstrumentViewModel> GetInstrumentNo(int bankAccountId)
        {
            var checkBook = from cc in dbCon.CbmCheque
                            join cb in dbCon.CbmChequeBook on cc.ChqBkId equals cb.Id
                            where cb.AccountId == bankAccountId && cc.Status == 1
                            orderby Convert.ToInt64(cc.ChqNum)
                            select new InstrumentViewModel
                            {
                                InstrumentId = cc.ChqId,
                                InstrumentNo = cb.Prefix + " " + cc.ChqNum
                            };

            var instrument = await checkBook.FirstOrDefaultAsync();
            if (instrument == null)
            {
                instrument = new InstrumentViewModel
                {
                    InstrumentId = 0,
                    InstrumentNo = "0"
                };
    }
            return instrument;

        }

        public async Task<RResult> UpdateCbmCheque(CbmCheque model, bool? saveChange = true)
        {
            RResult rResult = new RResult();
            try
            {
                var entity = await dbCon.CbmCheque.Where(x => x.ChqId == model.ChqId).FirstAsync();
                entity.Status = model.Status;
                entity.ChqAmount = model.ChqAmount;
                entity.ChqDate = model.ChqDate;
                entity.ChqDescription = model.ChqDescription;
                entity.VoucherId = model.VoucherId;
                entity.ChequeSignatoryId = model.ChequeSignatoryId;

                await dbCon.SaveChangesAsync();
                rResult.result = 1;
                rResult.message = ReturnMessage.UpdateMessage;
                rResult.longId = (long)entity.ChqBkId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return rResult;

        }
    }
}
