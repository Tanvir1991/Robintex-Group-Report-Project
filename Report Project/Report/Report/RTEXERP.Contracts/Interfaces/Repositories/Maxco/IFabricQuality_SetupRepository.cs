using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.DBEntities.Maxco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
    public interface IFabricQuality_SetupRepository :IGenericRepository<FabricQuality_Setup>
    {
        Task<List<SelectListItem>> DDLFabricQuality(int TypeID);

    }
}
