using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class FabricQuality_SetupService : IFabricQuality_SetupService
    {
        private readonly IFabricQuality_SetupRepository fabricQuality_SetupRepository;
        public FabricQuality_SetupService(IFabricQuality_SetupRepository fabricQuality_SetupRepository)
        {
            this.fabricQuality_SetupRepository = fabricQuality_SetupRepository;
        }

        public async Task<List<SelectListItem>> DDLFabricQuality(int FabricTypeID)
        {
            return await this.fabricQuality_SetupRepository.DDLFabricQuality(FabricTypeID);
        }
    }
}
