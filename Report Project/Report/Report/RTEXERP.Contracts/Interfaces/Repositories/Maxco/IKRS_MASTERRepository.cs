using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.DBEntities.Maxco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.Maxco
{
   public interface IKRS_MASTERRepository:IGenericRepository<KRS_MASTER>
    {
        Task<List<KRSOrderFabricSPModel>> GetKRSOrderFabricList(int kRSID = 0, int orderID = 0);
    }
}
