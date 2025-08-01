using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class vw_OrderGarmentAssortmentOrder_PantoneService : Ivw_OrderGarmentAssortmentOrder_PantoneService
    {
        private readonly Ivw_OrderGarmentAssortmentOrder_PantoneRepository ivw_OrderGarmentAssortmentOrder_PantoneRepository;

        public vw_OrderGarmentAssortmentOrder_PantoneService(Ivw_OrderGarmentAssortmentOrder_PantoneRepository _ivw_OrderGarmentAssortmentOrder_PantoneRepository)
        {
            ivw_OrderGarmentAssortmentOrder_PantoneRepository = _ivw_OrderGarmentAssortmentOrder_PantoneRepository;
        }
        public async Task<List<SelectListItem>> DDLGetOrderStyleColor(int styleID)
        {
            return await ivw_OrderGarmentAssortmentOrder_PantoneRepository.DDLGetOrderStyleColor(styleID);
        }
    }
}
