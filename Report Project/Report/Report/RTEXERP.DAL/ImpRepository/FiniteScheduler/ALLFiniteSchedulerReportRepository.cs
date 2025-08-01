using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.FiniteScheduler;
using RTEXERP.DAL.DataContext;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.FiniteScheduler
{
    public class ALLFiniteSchedulerReportRepository : GenericRepository<FabricStockReportSPModel>, IALLFiniteSchedulerReportRepository
    {
        private FiniteSchedulerDBContext dbCon;
        public ALLFiniteSchedulerReportRepository(FiniteSchedulerDBContext context)
            : base(context)
        {
            dbCon = context;
        }

        public async Task<List<FabricStockReportSPModel>> GetFabricLotStockList(int LotID, int AttributeInstanceID, DateTime DateTo)
        {
            var itemList = new List<FabricStockReportSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_GetFabricLotStockList")
                     .WithSqlParam("LotID", LotID)
                     .WithSqlParam("AttributeInstanceID", AttributeInstanceID)
                             .WithSqlParam("DateTo", DateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<FabricStockReportSPModel>() as List<FabricStockReportSPModel>;
                             });
                var sl = 1;
                itemList.ForEach(x => { x.Sl = sl++; });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<FabricStockReportSPModel>> GetFinishFabricStockList(DateTime DateTo)
        {
            var itemList = new List<FabricStockReportSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_GetFinishFabricStockList")
                             .WithSqlParam("DateTo", DateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<FabricStockReportSPModel>() as List<FabricStockReportSPModel>;
                             });
                var sl = 1;
                itemList.ForEach(x => { x.Sl = sl++; });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<FabricStockReportSPModel>> GetGreigeFabricStockList(DateTime DateTo)
        {
            var itemList = new List<FabricStockReportSPModel>();
            try
            {
                await dbCon.LoadStoredProc("MaterialsManagement.rpt.usp_GetGreigeFabricStockList")
                             .WithSqlParam("DateTo", DateTo)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<FabricStockReportSPModel>() as List<FabricStockReportSPModel>;
                             });
                var sl = 1;
                itemList.ForEach(x => { x.Sl = sl++; });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }        
    }
}
