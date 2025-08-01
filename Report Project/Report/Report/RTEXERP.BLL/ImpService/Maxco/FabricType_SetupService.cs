using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class FabricType_SetupService : IFabricType_SetupService
    {
        private readonly IFabricType_SetupRepository fabricType_SetupRepository;
        public FabricType_SetupService(IFabricType_SetupRepository fabricType_SetupRepository)
        {
            this.fabricType_SetupRepository = fabricType_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLFabricType()
        {
            return await this.fabricType_SetupRepository.DDLFabricType();
        }
    }
}
