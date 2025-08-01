using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
   public class Buyer_SetupService : IBuyer_SetupService
    {
        public IBuyer_SetupRepository buyer_SetupRepository;
        public Buyer_SetupService(IBuyer_SetupRepository buyer_SetupRepository)
        {
            this.buyer_SetupRepository = buyer_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLBuyer()
        {
            return await this.buyer_SetupRepository.DDLBuyer();
        }
    }
}
