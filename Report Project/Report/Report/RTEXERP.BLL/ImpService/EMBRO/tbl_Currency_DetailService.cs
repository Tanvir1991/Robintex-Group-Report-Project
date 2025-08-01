using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using RTEXERP.DBEntities.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{

    public class tbl_Currency_DetailService : Itbl_Currency_DetailService
    {
        private readonly Itbl_Currency_DetailRepository itbl_Currency_DetailRepository;
        public tbl_Currency_DetailService(Itbl_Currency_DetailRepository itbl_Currency_DetailRepository)
        {
            this.itbl_Currency_DetailRepository = itbl_Currency_DetailRepository;
        }

        public async Task<tbl_Currency_Detail> GetCurrencyRate(long CurrencyId)
        {
            return await itbl_Currency_DetailRepository.GetCurrencyRate(CurrencyId);
        }

        public async Task<tbl_Currency_Detail> GetDateCurrencyRate(DateTime CurrencyDate, long CurrencyId)
        {
            return await this.itbl_Currency_DetailRepository.GetDateCurrencyRate(CurrencyDate, CurrencyId);
        }
    }
}