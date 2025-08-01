using Microsoft.AspNetCore.Mvc.Rendering;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class MaxcoDDLService : IMaxcoDDLService
    {
        public readonly IMaxcoDDLRepository maxcoDDLRepository;
        public MaxcoDDLService(IMaxcoDDLRepository maxcoDDLRepository)
        {
            this.maxcoDDLRepository = maxcoDDLRepository;

        }

        public async Task<List<SelectListItem>> DDLLCNoList()
        {
            return await this.maxcoDDLRepository.DDLLCNoList();
        }

        public async Task<List<SelectListItem>> DDLTrims()
        {
            return await maxcoDDLRepository.DDLTrims();
        }

        public async Task<List<SelectListItem>> DDLYarnComposition()
        {
            return await this.maxcoDDLRepository.DDLYarnComposition();
        }

        public async Task<List<SelectListItem>> DDLYarnCompositionSTR()
        {
            return await this.maxcoDDLRepository.DDLYarnCompositionSTR();
        }

        public async Task<List<SelectListItem>> DDLYarnCount(int CompositionId)
        {
            return await this.maxcoDDLRepository.DDLYarnCount(CompositionId);
        }

        public async Task<List<SelectListItem>> DDLYarnCountALLSTR()
        {
            return await this.maxcoDDLRepository.DDLYarnCountALLSTR();
        }

        public async Task<List<SelectListItem>> DDLYarnCountValue(int CompositionId)
        {
            return await this.maxcoDDLRepository.DDLYarnCountValue(CompositionId);
        }

        public async Task<List<BasicModel>> GETFabricComposition(string Composition)
        {
            return await maxcoDDLRepository.GETFabricComposition(Composition);
        }

     
    }
}
