using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.EMBRO
{

    public class tbl_Currency_DetailRepository : GenericRepository<tbl_Currency_Detail>, Itbl_Currency_DetailRepository
    {

        private EmbroDBContext dbCon;

        public tbl_Currency_DetailRepository(EmbroDBContext context)
            : base(context)
        {
            dbCon = context;

        }

        public async Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId)
        {
            try
            {
                var currencyList = await dbCon.TblCurrencyDetail.Where(b => b.CurId == CurrencyId)
                     .Select(b=> new tbl_Currency_Detail
                     { CurId = b.CurId.Value,
                     Date = b.Date,
                     EnteredBy = b.EnteredBy,
                     RateInPakRs = b.RateInPakRs

                     }).ToListAsync();
                var maxDate = currencyList.Max(b => b.Date);
                var data = currencyList.Where(b => b.Date == maxDate).FirstOrDefault();
                return data;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<tbl_Currency_Detail> GetDateCurrencyRate(DateTime CurrencyDate, long CurrencyId)
        {
               var currencyList = await dbCon.TblCurrencyDetail.Where(b => b.CurId == CurrencyId && b.Date <= CurrencyDate)
                    .Select(b => new tbl_Currency_Detail
                    {
                        CurId = b.CurId.Value,
                        Date = b.Date,
                        EnteredBy = b.EnteredBy,
                        RateInPakRs = b.RateInPakRs

                    }).ToListAsync();
            var maxDate = currencyList.Max(b => b.Date);
            var data = currencyList.Where(b => b.Date == maxDate).FirstOrDefault();
            return data;
        }
    }
}