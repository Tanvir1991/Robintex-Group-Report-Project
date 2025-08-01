using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Maxco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public  interface IFabricType_SetupRepository :IGenericRepository<FabricType_Setup>
    {
        Task<List<SelectListItem>> DDLFabricType();
    }
}
