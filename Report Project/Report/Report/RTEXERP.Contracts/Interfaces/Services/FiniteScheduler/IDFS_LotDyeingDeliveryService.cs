using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Common;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.FiniteScheduler
{
  public  interface IDFS_LotDyeingDeliveryService
    {
        Task<RResult> Insert(DFS_LotDyeingDeliveryVM model);

        Task<RResult> Remove(DFS_LotDyeingDeliveryVM model);
        Task<RResult> Update(DFS_LotDyeingDeliveryVM model);

        Task<List<DFS_LotDyeingDeliveryVM>> GetLotDyeingDelivery(DateTime DateFrom,DateTime DateTo);
    }
}
