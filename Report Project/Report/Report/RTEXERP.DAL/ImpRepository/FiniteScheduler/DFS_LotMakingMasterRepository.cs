using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RTEXERP.Contracts.BLModels.FiniteScheduler;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.FiniteScheduler;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class DFS_LotMakingMasterRepository : GenericRepository<DFS_LotMakingMaster>, IDFS_LotMakingMasterRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public DFS_LotMakingMasterRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<SelectListItem>> DDLLot(DateTime CreationDateFrom, DateTime CreationDateTo,string Predict = null, long OrderID=0)
        {

            var dbList = dbCon.DFS_LotMakingMaster.Where(b => b.CreationDate != null
                                && b.CreationDate.Value.Date >= CreationDateFrom.Date
                                && b.CreationDate.Value.Date <= CreationDateTo.Date);
            if(Predict!=null && Predict.Length > 0)
            {
                dbList = dbList.Where(b => b.LotNo.Contains(Predict));
            }


             var nlist=dbList.Select(b => new SelectListItem
                               {
                                   Text = b.LotNo.Trim(),
                                   Value = b.ID.ToString()
                               });
            return await nlist.ToListAsync();
        }

        public async Task<List<SelectListItem>> DDLLotRequisition(DateTime LotDateFrom, DateTime LotDateTo, string Predict = null, long OrderID=0)
        {
            var OrderList = new List<SelectListItem>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetLotRequisitionID")
                              .WithSqlParam("LotDateFrom", LotDateFrom)
                              .WithSqlParam("LotDateTo", LotDateTo)
                              .WithSqlParam("Predict", Predict)
                               .WithSqlParam("OrderID", OrderID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 OrderList = handler.ReadToList<SelectListItem>() as List<SelectListItem>;
                             });
                return OrderList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<OrderWiseLotRequisitionVM>> GetOrderWiseLotRequisitionList(int OrderID)
        {
            var lotList = new List<OrderWiseLotRequisitionVM>();
            try
            {
                await dbCon.LoadStoredProc("ajt.USP_GetOrderWiseLotRequisitionList")  
                               .WithSqlParam("OrderID", OrderID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 lotList = handler.ReadToList<OrderWiseLotRequisitionVM>() as List<OrderWiseLotRequisitionVM>;
                             });
                return lotList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
