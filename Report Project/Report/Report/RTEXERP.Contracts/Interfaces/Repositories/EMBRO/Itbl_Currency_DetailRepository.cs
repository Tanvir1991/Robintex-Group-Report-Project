using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.EMBRO
{
  public  interface Itbl_Currency_DetailRepository
    {
        Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId);
        Task<tbl_Currency_Detail> GetDateCurrencyRate(DateTime CurrencyDate,long CurrencyId);
    }
}
