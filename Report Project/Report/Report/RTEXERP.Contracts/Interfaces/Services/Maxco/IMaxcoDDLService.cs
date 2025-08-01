using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.Maxco
{
    public interface IMaxcoDDLService
    {
        Task<List<SelectListItem>> DDLYarnCount(int CompositionId);
        Task<List<SelectListItem>> DDLYarnComposition();
       Task<List<SelectListItem>> DDLYarnCountValue(int CompositionId);
        Task<List<SelectListItem>> DDLLCNoList();
        Task<List<SelectListItem>> DDLTrims();
        Task<List<BasicModel>> GETFabricComposition(string Composition);

        Task<List<SelectListItem>> DDLYarnCountALLSTR();
        Task<List<SelectListItem>> DDLYarnCompositionSTR();


    }
}
