using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler
{
  public  interface IDFS_LotDyeingDeliveryRepository :IGenericRepository<DFS_LotDyeingDelivery>
    {
        Task<List<DFS_LotDyeingDeliveryVM>> GetLotDyeingDelivery(DateTime DateFrom, DateTime DateTo);
    }
}
