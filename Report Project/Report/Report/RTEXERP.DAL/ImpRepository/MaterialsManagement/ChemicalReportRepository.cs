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
    public class ChemicalReportRepository : GenericRepository<ChemicalStockSPModel>, IChemicalReportRepository
    {
        private MaterialsManagementDBContext dbCon;
        public ChemicalReportRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;
        }
        public async Task<List<ChemicalStockSPModel>> GetChemicalStock(int CompanyID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction)
        {
            var itemList = new List<ChemicalStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.USP_GetChemicalAndGeneralStockStatus")
                    .WithSqlParam("CompanyID", CompanyID)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("ReportItemType", ReportItemType)
                              .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<ChemicalStockSPModel>() as List<ChemicalStockSPModel>;
                             });
                return itemList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<ChemicalStockSPModel>> GetChemicalItemDetail(int CompanyID, int ItemID, int UnitID, DateTime DateFrom, DateTime DateTo, string ReportItemType, int WithAllTransaction)
        {
            var itemList = new List<ChemicalStockSPModel>();
            try
            {
                await dbCon.LoadStoredProc("rpt.USP_GetChemicalAndGeneralItemDetailReport")
                    .WithSqlParam("CompanyID", CompanyID)
                     .WithSqlParam("ItemID", ItemID)
                      .WithSqlParam("UnitID", UnitID)
                             .WithSqlParam("DateFrom", DateFrom)
                             .WithSqlParam("DateTo", DateTo)
                             .WithSqlParam("ReportItemType", ReportItemType)
                              .WithSqlParam("WithAllTransaction", WithAllTransaction)
                             .ExecuteStoredProcAsync((handler) =>
                             {
                                 itemList = handler.ReadToList<ChemicalStockSPModel>() as List<ChemicalStockSPModel>;
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
