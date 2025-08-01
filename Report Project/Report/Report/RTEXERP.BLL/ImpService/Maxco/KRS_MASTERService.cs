using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.Maxco;
using RTEXERP.Contracts.Interfaces.Services.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.BLL.ImpService.Maxco
{
    public class KRS_MASTERService : IKRS_MASTERService
    {
        private readonly IKRS_MASTERRepository kRS_MASTERRepository;

        public KRS_MASTERService(IKRS_MASTERRepository _kRS_MASTERRepository)
        {
            kRS_MASTERRepository = _kRS_MASTERRepository;
        }
        public async Task<List<KRSOrderFabricSPModel>> GetKRSOrderFabricList(int kRSID = 0, int orderID = 0)
        {
            return await kRS_MASTERRepository.GetKRSOrderFabricList(kRSID, orderID);
        }
    }
}
