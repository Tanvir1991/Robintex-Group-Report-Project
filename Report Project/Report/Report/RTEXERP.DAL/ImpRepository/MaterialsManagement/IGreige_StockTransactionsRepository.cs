using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement;
using RTEXERP.DAL.DataContext;
using RTEXERP.DBEntities.MaterialsManagement;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.DAL.ImpRepository.MaterialsManagement
{
    public class Greige_StockTransactionsRepository : GenericRepository<Greige_StockTransactions>, IGreige_StockTransactionsRepository
    {
        private MaterialsManagementDBContext dbCon;

        public Greige_StockTransactionsRepository(MaterialsManagementDBContext context)
            : base(context)
        {
            dbCon = context;

        }
        public async Task<List<GetKnittingProductionSPModel>> GetKnittingProduction(DateTime DateFrom, DateTime DateTo, int CompanyID = 0, int MachineID = -1)
        {
            List<GetKnittingProductionSPModel> greigeFabric = new List<GetKnittingProductionSPModel>();
           
            try
            {
                await dbCon.LoadStoredProc("ajt.GetKnittingProduction", commandTimeout: 20000)
                        .WithSqlParam("DateFrom", DateFrom.Date)
                        .WithSqlParam("DateTo", DateTo.Date)
                        .WithSqlParam("CompanyID", CompanyID)
                        .WithSqlParam("MachineID", MachineID)
                        .WithSqlParam("IsIncludeSubContactMachine",0)
                     
                .ExecuteStoredProcAsync((handler) =>
                {
                    greigeFabric = handler.ReadToList<GetKnittingProductionSPModel>() as List<GetKnittingProductionSPModel>;
                    
                });

            }
            catch (Exception e)
            {
                throw;
            }
            return greigeFabric;

        }

        public async Task<List<MachineProductionRollSPModel>> GetMachineProductionRollDetails(DateTime DateFrom, DateTime DateTo, int MachineID = 0)
        {
            List<MachineProductionRollSPModel> machineProduction = new List<MachineProductionRollSPModel>();

            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetMachineProductionRollDetails", commandTimeout: 20000)
                        .WithSqlParam("DateFrom", DateFrom.Date)
                        .WithSqlParam("DateTo", DateTo.Date)
                       
                        .WithSqlParam("MachineID", MachineID)
                        //.WithSqlParam("IsIncludeSubContactMachine", 0)

                .ExecuteStoredProcAsync((handler) =>
                {
                    machineProduction = handler.ReadToList<MachineProductionRollSPModel>() as List<MachineProductionRollSPModel>;

                });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return machineProduction;

        }

        public async Task<List<OrderKnittingProductionSPModel>> GetOrderKnittingProduction( long OrderID )
        {
            List<OrderKnittingProductionSPModel> orderKnittingProduction = new List<OrderKnittingProductionSPModel>();

            try
            {
                await dbCon.LoadStoredProc("ajt.usp_GetOrderKnittingProduction", commandTimeout: 20000)
                        .WithSqlParam("OrderID", OrderID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    orderKnittingProduction = handler.ReadToList<OrderKnittingProductionSPModel>() as List<OrderKnittingProductionSPModel>;

                });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orderKnittingProduction;

        }
    }
}
