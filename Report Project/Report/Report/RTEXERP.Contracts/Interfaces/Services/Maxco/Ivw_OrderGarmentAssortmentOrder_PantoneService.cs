using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
   public interface Ivw_OrderGarmentAssortmentOrder_PantoneService
    {
        Task<List<SelectListItem>> DDLGetOrderStyleColor(int styleID);
    }
}
