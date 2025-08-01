using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class DFS_LotDyeingDeliveryRepository : GenericRepository<DFS_LotDyeingDelivery>, IDFS_LotDyeingDeliveryRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public DFS_LotDyeingDeliveryRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<DFS_LotDyeingDeliveryVM>> GetLotDyeingDelivery(DateTime DateFrom, DateTime DateTo)
        {
            var dbDataQuery = from lot in dbCon.DFS_LotMakingMaster
                              join ul in dbCon.DFS_LotDyeingDelivery on lot.ID equals ul.LotID
                              where ul.IsRemoved == false
                              && ul.CreatedDate.Date >= DateFrom.Date && ul.CreatedDate.Date <= DateTo.Date
                              select new DFS_LotDyeingDeliveryVM
                              {
                                  LotNo = lot.LotNo.Trim(),
                                  LotID = ul.LotID,
                                  Remarks = ul.Remarks,
                                  LotConfirmDate = ul.LotConfirmDate,
                                  ID = ul.ID
                              };

            var rtnData = await dbDataQuery.ToListAsync();
            return rtnData;

        }
    }
}
