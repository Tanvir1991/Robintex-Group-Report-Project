using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Maxco.DB_Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface Ivw_OrderGarmentAssortmentOrder_PantoneRepository:IGenericRepository<vw_OrderGarmentAssortmentOrder_Pantone>
    {
        Task<List<SelectListItem>> DDLGetOrderStyleColor(int styleID);
    }
}
