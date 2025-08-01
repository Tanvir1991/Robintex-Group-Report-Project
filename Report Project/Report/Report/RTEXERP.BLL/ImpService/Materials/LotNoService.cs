using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Materials;
using RTEXERP.Contracts.Interfaces.Services.Materials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Materials
{
  public  class LotNoService : ILotNoService
    {
        ILotNoRepository lotNoRepository;
        public LotNoService(ILotNoRepository lotNoRepository) {
            this.lotNoRepository = lotNoRepository;
        }

        

      public async  Task<List<SelectListItem>> DDLLotList(DateTime? DateFrom,DateTime? DateTo)
        {
            return  await lotNoRepository.DDLLotList(DateFrom,DateTo);
        }

        
    }
}
