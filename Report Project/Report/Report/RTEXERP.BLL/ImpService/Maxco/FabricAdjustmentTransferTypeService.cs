using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class FabricAdjustmentTransferTypeService : IFabricAdjustmentTransferTypeService
    {
        private readonly IFabricAdjustmentTransferTypeRepository fabricAdjustmentTransferTypeRepository;

        public FabricAdjustmentTransferTypeService(IFabricAdjustmentTransferTypeRepository _fabricAdjustmentTransferTypeRepository)
        {
            fabricAdjustmentTransferTypeRepository = _fabricAdjustmentTransferTypeRepository;
        }
        public async Task<List<SelectListItem>> DDLFabricAdjustmentTransferType()
        {
            return await fabricAdjustmentTransferTypeRepository.DDLFabricAdjustmentTransferType();
        }
    }
}
