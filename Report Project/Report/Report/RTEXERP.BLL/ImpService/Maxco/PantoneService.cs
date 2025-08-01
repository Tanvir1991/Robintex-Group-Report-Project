using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class PantoneService : IPantoneService
    {
        private readonly IPantoneRepository pantoneRepository;
        public PantoneService(IPantoneRepository pantoneRepository)
        {
            this.pantoneRepository = pantoneRepository;
        }

        public async Task<List<BasicModel>> GetPantoneColor(string ColorName, int limit = 15)
        {
            return await this.pantoneRepository.GetPantoneColor(ColorName,limit);
        }
    }
}
