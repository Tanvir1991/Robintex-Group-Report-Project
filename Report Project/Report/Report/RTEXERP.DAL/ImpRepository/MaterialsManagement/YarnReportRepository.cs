using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class YarnReportRepository :GenericRepository<YarnStockSPModel>, IYarnReportRepository
    {
        private MaterialsManagementDBContext dbCon;
        public YarnReportRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<YarnStockSPModel>> GetYarnStock(DateTime DateFrom, DateTime DateTo, int WithAllTransaction)
        {
            var itemList = new List<YarnStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("ajt.GetYarnStock")
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                              .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<YarnStockSPModel>() as List<YarnStockSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
