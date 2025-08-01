using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.EMBRO;
using RTEXERP.Contracts.Interfaces.Services.EMBRO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.EMBRO
{
    public class CBM_Instrument_TypeService: ICBM_Instrument_TypeService
    {
        private readonly ICBM_Instrument_TypeRepository cBM_Instrument_TypeRepository;
        public CBM_Instrument_TypeService(ICBM_Instrument_TypeRepository cBM_Instrument_TypeRepository)
        {
            this.cBM_Instrument_TypeRepository = cBM_Instrument_TypeRepository;
        }

        public async Task<List<SelectListItem>> DDLCBM_Instrument_TypeList()
        {
            return await cBM_Instrument_TypeRepository.DDLCBM_Instrument_TypeList();
        }
    }
}
