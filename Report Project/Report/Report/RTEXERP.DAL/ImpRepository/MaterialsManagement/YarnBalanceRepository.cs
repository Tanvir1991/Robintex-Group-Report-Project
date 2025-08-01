using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.BLModels.Maxco.SPModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DAL.Extension;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
   public class YarnBalanceRepository:GenericRepository<CMBL_Sample>, IYarnBalanceRepository
    {
        private MaterialsManagementDBContext dbCon;
        
        public YarnBalanceRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
             
        }

        public async Task<List<YarnLotBalanceViewModel>> YarnLotBalanceSummaryByCountComposition(string LotNo, DateTime? DateFrom, DateTime? DateTo, string YarnCountId, int? YarnCompositionId, int IsDetails = 0)
        {
            var itemList = new List<YarnLotBalanceViewModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.usp_YarnLotBalanceSummaryByCountComposition")
                             .WithSqlParam("LotNo", LotNo)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("YarnCountId", YarnCountId)
                             .WithSqlParam("YarnCompositionId", YarnCompositionId)
                             .WithSqlParam("IsDetails", IsDetails)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<YarnLotBalanceViewModel>() as List<YarnLotBalanceViewModel>;
                             });



                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<YarnStockDetailsSPModel>> YarnStockDetails(string YarnComposition, string YarnCount, DateTime TransactionDate, long CompanyID)
        {
            var itemList = new List<YarnStockDetailsSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.YarnStockDetails")
                             .WithSqlParam("YarnComposition", YarnComposition)
                             .WithSqlParam("YarnCount", YarnCount)
                             .WithSqlParam("TransactionDate", TransactionDate)
                             .WithSqlParam("CompanyID", CompanyID)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<YarnStockDetailsSPModel>() as List<YarnStockDetailsSPModel>;
                             });



                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
             
        }
        public async Task<List<YarnStockDetailsSPModel>> YarnLotDetails(string LotNo)
        {
            var itemList = new List<YarnStockDetailsSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.YarnLotDetails")
                             .WithSqlParam("LotNo", LotNo)                             
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<YarnStockDetailsSPModel>() as List<YarnStockDetailsSPModel>;
                             });



                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public DataTable YarnSummaryCompositionWise(DateTime StockDate, int CompanyID = 0)
        {
            try
            {
                DbParameter[] parm = new DbParameter[2];
                parm[0] = new SqlParameter("StockDate", SqlDbType.Date) { Value = StockDate };
                parm[1] = new SqlParameter("CompanyID", SqlDbType.BigInt) { Value = (long)CompanyID };

                DataTable data = dbCon.DataTable("rpt.YarnStockSummary", parm);
                return data;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //rpt.usp_YarnLotBalanceSummaryByCountComposition(@LotNo Varchar(50)='',@DateFrom Date, @DateTo Date,@YarnCountId INT = 0, @YarnCompositionId INT=0,@IsDetails int=0)
    }
}
