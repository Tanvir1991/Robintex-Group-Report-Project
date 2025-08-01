using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IMaxcoDDLRepository : IGenericRepository<FabricYarnComposition_Setup>
    {
        Task<List<SelectListItem>> DDLYarnCount(int CompositionId);
       Task<List<SelectListItem>> DDLYarnCountValue(int CompositionId);
        Task<List<SelectListItem>> DDLYarnComposition();
        Task<List<SelectListItem>> DDLLCNoList();
        Task<List<SelectListItem>> DDLTrims();
        Task<List<SelectListItem>> DDLYarnCountALLSTR();
        Task<List<SelectListItem>> DDLYarnCompositionSTR();
        Task<List<BasicModel>> GETFabricComposition(string Composition);
 
    }
}
