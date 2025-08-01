using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using RTEXERP.DBEntities.MaterialsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Repositories.MaterialsManagement
{
  public  interface IGreige_StockTransactionsRepository :IGenericRepository<Greige_StockTransactions>
    {
        Task<List<GetKnittingProductionSPModel>> GetKnittingProduction(DateTime DateFrom,DateTime DateTo,int CompanyID=0,int MachineID=-1);
        Task<List<MachineProductionRollSPModel>> GetMachineProductionRollDetails(DateTime DateFrom, DateTime DateTo, int MachineID = 0);
        Task<List<OrderKnittingProductionSPModel>> GetOrderKnittingProduction(long OrderID);
    }
}
