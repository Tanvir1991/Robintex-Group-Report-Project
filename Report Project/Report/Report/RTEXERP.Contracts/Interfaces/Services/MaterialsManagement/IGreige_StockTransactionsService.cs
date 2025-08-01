using RTEXERP.Contracts.BLModels.MaterialsManagement;
using RTEXERP.Contracts.BLModels.MaterialsManagement.StockModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RTEXERP.Contracts.Interfaces.Services.MaterialsManagement
{
    public interface IGreige_StockTransactionsService
    {
        Task<List<GetKnittingProductionSPModel>> GetKnittingProduction(DateTime DateFrom, DateTime DateTo, int CompanyID = 0, int MachineID = -1);
        Task<List<MachineProductionRollSPModel>> GetMachineProductionRollDetails(DateTime DateFrom, DateTime DateTo, int MachineID = 0);
        Task<List<OrderKnittingProductionSPModel>> GetOrderKnittingProduction(long OrderID);
    }
}
